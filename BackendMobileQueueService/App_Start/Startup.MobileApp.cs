using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server.Config;
using BackendMobileQueueService.DataObjects;
using BackendMobileQueueService.Models;
using Owin;

namespace BackendMobileQueueService
{
    public partial class Startup
    {
        public static void ConfigureMobileApp(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            //For more information on Web API tracing, see http://go.microsoft.com/fwlink/?LinkId=620686 
            config.EnableSystemDiagnosticsTracing();

            new MobileAppConfiguration()
                .UseDefaultConfiguration()
                .ApplyTo(config);

            // Use Entity Framework Code First to create database tables based on your DbContext
            Database.SetInitializer(new BackendMobileQueueInitializer());

            // To prevent Entity Framework from modifying your database schema, use a null database initializer
            // Database.SetInitializer<BackendMobileQueueContext>(null);

            MobileAppSettingsDictionary settings = config.GetMobileAppSettingsProvider().GetMobileAppSettings();

            if (string.IsNullOrEmpty(settings.HostName))
            {
                // This middleware is intended to be used locally for debugging. By default, HostName will
                // only have a value when running in an App Service application.
                app.UseAppServiceAuthentication(new AppServiceAuthenticationOptions
                {
                    SigningKey = ConfigurationManager.AppSettings["SigningKey"],
                    ValidAudiences = new[] { ConfigurationManager.AppSettings["ValidAudience"] },
                    ValidIssuers = new[] { ConfigurationManager.AppSettings["ValidIssuer"] },
                    TokenHandler = config.GetAppServiceTokenHandler()
                });
            }
            app.UseWebApi(config);
        }
    }

    public class BackendMobileQueueInitializer : CreateDatabaseIfNotExists<BackendMobileQueueContext>
    {
        protected override void Seed(BackendMobileQueueContext context)
        {
            List<PostOffice> todoItems = new List<PostOffice>
            {
                new PostOffice { Id = Guid.NewGuid().ToString(), City = "Kraków", OpeningHours =  "08:00-20:00",Street="Bronowicka",PostalCode="30-091",State="Małopolskie" ,Url=string.Empty},
                new PostOffice { Id = Guid.NewGuid().ToString(), City = "Koszarawa", OpeningHours =  "07:00-15:00",Street="Koszarawa",PostalCode="34-332",State="Śląskie",Url=string.Empty},
            };

            foreach (PostOffice todoItem in todoItems)
            {
                context.Set<PostOffice>().Add(todoItem);
            }

            base.Seed(context);
        }
    }
}

