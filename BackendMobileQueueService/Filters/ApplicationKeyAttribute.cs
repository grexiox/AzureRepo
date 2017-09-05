using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace BackendMobileQueueService.Filters
{
    public class ApplicationKeyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!ValidateKey(actionContext.Request))
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
            }
            else
            {
                base.OnActionExecuting(actionContext);
            }
        }

        private bool ValidateKey(HttpRequestMessage message)
        {
            IEnumerable<string> values = null;
            bool isValid = false;

            if (message.Headers.TryGetValues("MY-APPLICATION-KEY", out values))
            {
                string appKey = values.FirstOrDefault();
                if (appKey.Equals(ConfigurationManager.AppSettings["ApplicationKey"], StringComparison.OrdinalIgnoreCase))
                {
                    isValid = true;
                }
            }

            return isValid;
        }
    }
}