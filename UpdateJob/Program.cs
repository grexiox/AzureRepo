using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using DbAccess;

namespace UpdateJob
{
    // To learn more about Microsoft Azure WebJobs SDK, please see https://go.microsoft.com/fwlink/?LinkID=320976
    class Program
    {
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        static void Main()
        {
            var config = new JobHostConfiguration();

            if (config.IsDevelopment)
            {
                config.UseDevelopmentSettings();
            }
            var host = new JobHost(config);

            using (var context = new BackendMobileQueueContext())
            {
                var posts = context.Values.ToList();
                Random r = new Random();
                foreach (var p in posts)
                {
                    int queue = r.Next(10);
                    p.Tendency = queue > p.StatusQueue ? true : false;
                    p.StatusQueue = queue;
                    p.ExpectedTime = queue * 2;
                }
                context.SaveChanges();
            }

            // The following code ensures that the WebJob will be running continuously
            host.RunAndBlock();
        }
    }
}
