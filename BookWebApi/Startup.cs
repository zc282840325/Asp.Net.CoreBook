using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Book.Comment;
using Book.Core.Entities;
using Book.Core.Interfaces;
using BookEFSqt.Infrastructure;
using BookEFSqt.Infrastructure.Database;
using BookEFSqt.Infrastructure.Repositories;
using BookEFSqt.Infrastructure.Resources;
using BookWebApi.File;
using BookWebApi.Tools;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
            #region ��������������
            services.AddControllers(o =>
            {
                // ȫ���쳣����
                o.Filters.Add(typeof(GlobalExceptionsFilter));
                // ȫ��·��Ȩ�޹�Լ
                //o.Conventions.Insert(0, new GlobalRouteAuthorizeConvention());
                // ȫ��·��ǰ׺��ͳһ�޸�·��
                o.Conventions.Insert(0, new GlobalRoutePrefixFilter(new RouteAttribute(RoutePrefix.Name)));
            })
            //ȫ������Json���л�����
            .AddNewtonsoftJson(options =>
            {
                //����ѭ������
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                //��ʹ���շ���ʽ��key
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                //����ʱ���ʽ
                //options.SerializerSettings.DateFormatString = "yyyy-MM-dd";
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

            services.RegisterAssembly("Book.Core", "BookEFSqt.Infrastructure");
            #endregion

            #region ���Jwt

            var jwtSetting = new JwtSettings();
            Configuration.Bind("Authentication:JwtBearer", jwtSetting);

            services.AddCors(options =>
            {
                options.AddPolicy("any", builder =>
                {
                    builder.AllowAnyOrigin() //�����κ���Դ����������
                    .AllowAnyMethod()
                    .AllowAnyHeader();

                });
            });
            //��֤
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(config =>
            {
                config.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,//�Ƿ���֤Issuer
                    ValidateAudience = true,//�Ƿ���֤Audience
                    ValidateLifetime = false,//�Ƿ���֤ʧЧʱ��
                    ValidateIssuerSigningKey = true,//�Ƿ���֤SecurityKey
                    ValidAudience = Configuration["Authentication:JwtBearer:Audience"],//Audience
                    ValidIssuer = Configuration["Authentication:JwtBearer:Issuer"],//Issuer���������ǰ��ǩ��jwt������һ��
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Authentication:JwtBearer:SecurityKey"]))//�õ�SecurityKey
                };
            });
            #endregion

            #region ���Swagger����
            services.AddSwaggerGen(c =>
            {
                //˵���ĵ�
                c.SwaggerDoc("v1", new OpenApiInfo {
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
        }
        /// <summary>
        /// ʹ�� Microsoft.AspNetCore.Authentication.JwtBearer
        /// </summary>
        /// <param name="services"></param>
        private void JWTConfig(IServiceCollection services)
        {
            services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));

            var jwtSeetings = new JwtSettings();
            //��jwtSeetings
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
            //���þ�̬�ļ�
            app.UseStaticFiles();

            // ���Swagger�й��м��
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Demo v1");
            });
            //�ض���
            app.UseHttpsRedirection();
            //·��
            app.UseRouting();
            //Ȩ��
            app.UseAuthentication();
            //����
            app.UseCors(builder =>
            {
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
                builder.AllowAnyOrigin();
                // builder.WithOrigins("http://localhost:8080");
            });
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
