using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yi.Framework.WebCore.BuilderExtend;

namespace Yi.Framework.SearchMicroservice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args) 
            .ConfigureAppConfiguration((hostBuilderContext, configurationBuilder) =>
  {
            configurationBuilder.AddCommandLine(args);
            configurationBuilder.AddJsonFileService();
            #region 
            //Apollo����
            #endregion
            configurationBuilder.AddApolloService("Yi");
        })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();

                  
                });
        
    }
}
