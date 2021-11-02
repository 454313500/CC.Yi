using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Yi.Framework.Model.ModelFactory;
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
            //Quartz�����������
            #endregion
            services.AddQuartzService();

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
            //���ݿ�����
            #endregion
            services.AddDbService();

            #region
            //Redis��������
            #endregion
            services.AddRedisService();

            #region
            //RabbitMQ��������
            #endregion
            services.AddRabbitMQService();


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
        public  void Configure(IApplicationBuilder app, IWebHostEnvironment env,IDbContextFactory _DbFactory)
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
            //app.UseErrorHandlingService();

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
            app.UseHealthCheckMiddleware();

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
            app.UseConsulService();

            #region
            //���ݿ�����ע��
            #endregion
            app.UseDbSeedInitService(_DbFactory);

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
