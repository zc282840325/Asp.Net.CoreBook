using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Book.Comment;
using Book.Core.EntityFramWork;
using Book.Core.EntityFramWork.Database;
using BookManagerWeb.Filert;
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
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BookManagerWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(option =>
            {
                option.EnableEndpointRouting = false;
                option.Filters.Add(typeof(SampleActionFilter));//ͨ������
                option.Filters.Add(new SampleActionFilter());//ע��ʵ��
            })
       .AddNewtonsoftJson();

            #region ע��Cookie
            //ע��Cookie��֤����
            services
            .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, option =>
            {
                option.Cookie.Name = "BookTokenCookie";//���ô洢�û���¼��Ϣ���û�Token��Ϣ����Cookie����
                option.Cookie.HttpOnly = true;//���ô洢�û���¼��Ϣ���û�Token��Ϣ����Cookie���޷�ͨ���ͻ���������ű�(��JavaScript��)���ʵ�
                option.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.Always;//���ô洢�û���¼��Ϣ���û�Token��Ϣ����Cookie��ֻ��ͨ��HTTPSЭ�鴫�ݣ������HTTPЭ�飬Cookie���ᱻ���͡�ע�⣬option.Cookie.SecurePolicy���Ե�Ĭ��ֵ��Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest
            });

            #endregion

            #region ע��Mapper����
            services.AddAutoMapper(typeof(ServiceProfiles));
            #endregion

            #region ���SQL���ݿ�����

            var sqlConnection = Configuration.GetConnectionString("SqlServerConnection");
            services.AddDbContext<BookContext>(option => option.UseSqlServer(sqlConnection));
            #endregion

            #region ע�����
            services.RegisterAssembly("Book.Core.IRepository", "Book.Core.Repository");
            services.RegisterAssembly("Book.Core.IServices", "Book.Core.Services");
            #endregion

            #region ���Jwt

            var jwtSetting = new JwtSettings();
            Configuration.Bind("Authentication:JwtBearer", jwtSetting);

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Authentication:JwtBearer:SecurityKey"]));
            //��֤
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //.AddJwtBearer(config =>
            //{
            //    config.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,//�Ƿ���֤Issuer
            //        ValidateAudience = true,//�Ƿ���֤Audience
            //        ValidateLifetime = false,//�Ƿ���֤ʧЧʱ��
            //        ValidateIssuerSigningKey = true,//�Ƿ���֤SecurityKey
            //        ValidAudience = Configuration["Authentication:JwtBearer:Audience"],//Audience
            //        ValidIssuer = Configuration["Authentication:JwtBearer:Issuer"],//Issuer���������ǰ��ǩ��jwt������һ��
            //        IssuerSigningKey = signingKey//�õ�SecurityKey
            //    };
            //});
            #endregion

            #region ��ӿ������
            services.AddCors(options =>
            {
                options.AddPolicy("any", builder =>
                {
                    builder.AllowAnyOrigin() //�����κ���Դ����������
                    .AllowAnyMethod()
                    .AllowAnyHeader();

                });
            });
            #endregion

            #region ���Swagger����
            services.AddSwaggerGen(c =>
            {
                //˵���ĵ�
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API Demo",
                    Version = "v1",
                    Description = "API for Books",
                    Contact = new OpenApiContact() { Name = "Books", Email = "282840325@qq.com" }
                });
                c.DocInclusionPredicate((docName, description) => true);

                //�����֤
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "JWT Bearer ��Ȩ \"Authorization:     Bearer+�ո�+token\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                //��ʾע����Ϣ
                c.IncludeXmlComments(System.IO.Path.Combine(System.AppContext.BaseDirectory, "BookWebApi.xml"));
                //3.1�汾���滻�����
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

            #region ��̬��
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            // ���Ҫ���ݿ⶯̬�󶨣������������գ���ߴ������ﶯ̬��ֵ
            var permission = new List<PermissionItem>();
            // ��ɫ��ӿڵ�Ȩ��Ҫ�����
            var permissionRequirement = new PermissionRequirement(
                "/api/denied",// �ܾ���Ȩ����ת��ַ��Ŀǰ���ã�
                permission,//���ﻹ�ǵ�ô�����������ϱ�˵���Ľ�ɫ��ַ��Ϣƾ��ʵ���� Permission
                ClaimTypes.Role,//���ڽ�ɫ����Ȩ
                Configuration["Authentication:JwtBearer:Issuer"],//������
                Configuration["Authentication:JwtBearer:Audience"],//������
                signingCredentials,//ǩ��ƾ��
                expiration: TimeSpan.FromSeconds(60 * 2)//�ӿڵĹ���ʱ�䣬ע������û���˻���ʱ�䣬��Ҳ�����Զ��壬���ϱߵ�TokenValidationParameters�� ClockSkew
                );

            #endregion

            #region ������Ȩ����Ҳ���Ǿ���Ĺ����Ѿ���Ӧ��Ȩ�޲��ԣ����繫˾��ͬȨ�޵��Ž���
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = false,//��֤�����˵�ǩ����Կ
                IssuerSigningKey = signingKey,
                ValidateIssuer = true,//��֤������
                ValidIssuer = Configuration["Authentication:JwtBearer:Issuer"],//������
                ValidateAudience = true,//��֤������
                ValidAudience = Configuration["Authentication:JwtBearer:Audience"],//������
                ValidateLifetime = true,//��֤��������
                ClockSkew = TimeSpan.Zero,//����Ƕ���Ĺ��ڵĻ���ʱ��
                RequireExpirationTime = true,//�Ƿ�Ҫ�����

            };

            services.AddAuthorization(options =>
            {
                // �Զ�����ڲ��Ե���ȨȨ��
                // 3�����ӵĲ�����Ȩ
                options.AddPolicy("Permission",
                         policy => policy.Requirements.Add(permissionRequirement));
            })
           // �� ����֮��������Ҫ������֤����������jwtBearerĬ����֤��������п�û�ã�����ʶ������
           .AddAuthentication(x =>
           {
               x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
               x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
               x.DefaultChallengeScheme = nameof(ApiResponseHandler);
               x.DefaultForbidScheme = nameof(ApiResponseHandler);
           })
           // �� ����֮�������JWT�����ã������Ž������ʶ��ģ��Ƿ��俨�����Ǵſ�
           .AddJwtBearer(o =>
           {
               o.TokenValidationParameters = tokenValidationParameters;
           }).AddScheme<AuthenticationSchemeOptions, ApiResponseHandler>(nameof(ApiResponseHandler), o => { });

            #endregion

            #region ע����Ȩ������
            services.AddScoped<IAuthorizationHandler, PermissionHandler>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            #endregion

            #region ����Ȩ��Ҫ��ע������������
            services.AddSingleton(permissionRequirement);
            #endregion

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            //���þ�̬�ļ�
            app.UseStaticFiles();

            // ���Swagger�й��м��
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Demo v1");
            });
            //�ض���
            //app.UseHttpsRedirection();
            //Ȩ��
            app.UseAuthorization();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
 
        }
    }
}
