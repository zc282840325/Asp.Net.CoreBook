using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using AutoMapper;
using Book.Comment;
using Book.Comment.GlobalVars;
using Book.Core.Entities;
using Book.Core.EntityFramWork;
using Book.Core.EntityFramWork.Database;
using Book.Core.EntityFramWork.Resources;
using Book.Core.IRepository;
using Book.Core.Repository;
using BookWebApi.AuthHelper.Policys;
using BookWebApi.Filter;
using BookWebApi.Tools;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BookWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region 控制器进行配置
            services.AddControllers(o =>
            {
                // 全局异常过滤
                o.Filters.Add(typeof(GlobalExceptionsFilter));
                // 全局路由权限公约
                //o.Conventions.Insert(0, new GlobalRouteAuthorizeConvention());
                // 全局路由前缀，统一修改路由
                o.Conventions.Insert(0, new GlobalRoutePrefixFilter(new RouteAttribute(Book.Comment.GlobalVars.RoutePrefix.Name)));
            })
            //全局配置Json序列化处理
            .AddNewtonsoftJson(options =>
            {
                //忽略循环引用
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                //不使用驼峰样式的key
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                //设置时间格式
                //options.SerializerSettings.DateFormatString = "yyyy-MM-dd";
            });
            #endregion

            #region 注入Cookie
            //注册Cookie认证服务
            services
            .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, option =>
            {
                option.Cookie.Name = "BookTokenCookie";//设置存储用户登录信息（用户Token信息）的Cookie名称
                option.Cookie.HttpOnly = true;//设置存储用户登录信息（用户Token信息）的Cookie，无法通过客户端浏览器脚本(如JavaScript等)访问到
                option.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.Always;//设置存储用户登录信息（用户Token信息）的Cookie，只会通过HTTPS协议传递，如果是HTTP协议，Cookie不会被发送。注意，option.Cookie.SecurePolicy属性的默认值是Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest
            });

            #endregion

            #region 注册Mapper服务
            services.AddAutoMapper(typeof(ServiceProfiles));
            #endregion

            #region 添加SQL数据库连接

            var sqlConnection = Configuration.GetConnectionString("SqlServerConnection");
            services.AddDbContext<BookContext>(option => option.UseSqlServer(sqlConnection));
            #endregion

            #region 注入服务
            services.RegisterAssembly("Book.Core.IRepository", "Book.Core.Repository");
            services.RegisterAssembly("Book.Core.IServices", "Book.Core.Services");
            #endregion

            #region 添加Jwt

            var jwtSetting = new JwtSettings();
            Configuration.Bind("Authentication:JwtBearer", jwtSetting);

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Authentication:JwtBearer:SecurityKey"]));
          
            #endregion

            #region 添加跨域服务
            services.AddCors(options =>
            {
                options.AddPolicy("any", builder =>
                {
                    builder.AllowAnyOrigin() //允许任何来源的主机访问
                    .AllowAnyMethod()
                    .AllowAnyHeader();

                });
            });
            #endregion

            #region 添加Swagger配置
            services.AddSwaggerGen(c =>
            {
                //说明文档
                c.SwaggerDoc("v1", new OpenApiInfo {
                    Title = "API Demo",
                    Version = "v1",
                    Description = "API for Books",
                    Contact = new OpenApiContact() { Name = "Books", Email = "282840325@qq.com" }
                });
                c.DocInclusionPredicate((docName, description) => true);

                //添加验证
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "JWT Bearer 授权 \"Authorization:     Bearer+空格+token\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);
                Console.WriteLine("basePath:" + basePath);
                var commentsFileName = "BookWebApi.XML";
                var xmlPath = Path.Combine(basePath, commentsFileName);
                //显示注释信息
                c.IncludeXmlComments(xmlPath);
            
                //3.1版本的替换需添加
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });

            });
            #endregion

            #region 动态绑定
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            // 如果要数据库动态绑定，这里先留个空，后边处理器里动态赋值
            var permission = new List<PermissionItem>();
            // 角色与接口的权限要求参数
            var permissionRequirement = new PermissionRequirement(
                "/api/denied",// 拒绝授权的跳转地址（目前无用）
                permission,//这里还记得么，就是我们上边说到的角色地址信息凭据实体类 Permission
                ClaimTypes.Role,//基于角色的授权
                Configuration["Authentication:JwtBearer:Issuer"],//发行人
                Configuration["Authentication:JwtBearer:Audience"],//订阅人
                signingCredentials,//签名凭据
                expiration: TimeSpan.FromSeconds(60 * 2)//接口的过期时间，注意这里没有了缓冲时间，你也可以自定义，在上边的TokenValidationParameters的 ClockSkew
                );

            #endregion

            #region 配置授权服务，也就是具体的规则，已经对应的权限策略，比如公司不同权限的门禁卡
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = false,//验证发行人的签名密钥
                IssuerSigningKey = signingKey,
                ValidateIssuer = true,//验证发行人
                ValidIssuer = Configuration["Authentication:JwtBearer:Issuer"],//发行人
                ValidateAudience = true,//验证订阅人
                ValidAudience = Configuration["Authentication:JwtBearer:Audience"],//订阅人
                ValidateLifetime = true,//验证生命周期
                ClockSkew = TimeSpan.Zero,//这个是定义的过期的缓存时间
                RequireExpirationTime = true,//是否要求过期

            };

            services.AddAuthorization(options =>
            {
                // 自定义基于策略的授权权限
                // 3、复杂的策略授权
                    options.AddPolicy("Permission",
                             policy => policy.Requirements.Add(permissionRequirement));
            })
           // ② 核心之二，必需要配置认证服务，这里是jwtBearer默认认证，比如光有卡没用，得能识别他们
           .AddAuthentication(x =>
           {
               x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
               x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
               x.DefaultChallengeScheme = nameof(ApiResponseHandler);
               x.DefaultForbidScheme = nameof(ApiResponseHandler);
           })
           // ③ 核心之三，针对JWT的配置，比如门禁是如何识别的，是放射卡，还是磁卡
           .AddJwtBearer(o =>
           {
               o.TokenValidationParameters = tokenValidationParameters;
           }).AddScheme<AuthenticationSchemeOptions, ApiResponseHandler>(nameof(ApiResponseHandler), o => { });

            #endregion

            #region 注入授权处理器
            services.AddScoped<IAuthorizationHandler, PermissionHandler>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            #endregion

            #region 将授权必要类注入生命周期内
            services.AddSingleton(permissionRequirement);
            #endregion
        }
        /// <summary>
        /// 使用 Microsoft.AspNetCore.Authentication.JwtBearer
        /// </summary>
        /// <param name="services"></param>
        private void JWTConfig(IServiceCollection services)
        {
            services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));

            var jwtSeetings = new JwtSettings();
            //绑定jwtSeetings
            Configuration.Bind("JwtSettings", jwtSeetings);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = jwtSeetings.Issuer,
                    ValidAudience = jwtSeetings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSeetings.SecurityKey))
                };
            });

        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //引用静态文件
            app.UseStaticFiles();

            // 添加Swagger有关中间件
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Demo v1");
            });
            //重定向
            app.UseHttpsRedirection();
            //路由
            app.UseRouting();
         
            //跨域
            app.UseCors(builder =>
            {
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
                builder.AllowAnyOrigin();
            });

            //权限
            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
     
        }
    }
}
