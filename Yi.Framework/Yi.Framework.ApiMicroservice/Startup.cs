using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yi.Framework.Common.IOCOptions;
using Yi.Framework.Interface;
using Yi.Framework.Model;
using Yi.Framework.Service;
using Yi.Framework.WebCore;
using Yi.Framework.WebCore.FilterExtend;
using Yi.Framework.WebCore.MiddlewareExtend;
using Yi.Framework.WebCore.Utility;

namespace Yi.Framework.ApiMicroservice
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
            #region
            //Ioc����
            #endregion
            services.AddIocService(Configuration);

            #region
            //������+����������
            #endregion
            services.AddControllers(optios=> {
                //optios.Filters.Add(typeof(CustomExceptionFilterAttribute));
            });

            #region
            //Swagger��������
            #endregion
            services.AddSwaggerService<Program>();

            #region
            //�����������
            #endregion
            services.AddCorsService();

            #region
            //Jwt��Ȩ����
            #endregion
            services.AddJwtService();

            #region
            //Sqlite��������
            #endregion
            services.AddSqliteService();

            #region
            //Redis��������
            #endregion
            //services.AddRedisService();

            #region
            //RabbitMQ��������
            #endregion
            //services.AddRabbitMQService();

            
        }

        #region Autofac����ע��
        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            #region
            //����Module����ע��
            #endregion
            containerBuilder.RegisterModule<CustomAutofacModule>();
        }
        #endregion

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public  void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            {
                #region
                //����ҳ��ע��
                #endregion
                app.UseDeveloperExceptionPage();

                #region
                //Swagger����ע��
                #endregion
                app.UseSwaggerService();
            }
            #region
            //����ץȡ����ע��
            #endregion
            app.UseErrorHandlingService();

            #region
            //HttpsRedirectionע��
            #endregion
            app.UseHttpsRedirection();

            #region
            //·��ע��
            #endregion
            app.UseRouting();

            #region
            //�������ע��
            #endregion
            app.UseCorsService();

            #region
            //�������ע��
            #endregion
            //app.UseHealthCheckMiddleware();

            #region
            //��Ȩע��
            #endregion
            app.UseAuthentication();

            #region
            //��Ȩע��
            #endregion
            app.UseAuthorization();

            #region
            //Consul����ע��
            #endregion
            //await app.UseConsulService();

            #region
            //Endpointsע��
            #endregion
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
