using BackendMobileQueueService.DataObjects.JsonObject;
using BackendMobileQueueService.Models;
using Microsoft.Azure.Mobile.Server.Config;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using BackendMobileQueueService.DataObjects;
using System;

namespace BackendMobileQueueService.Controllers
{
    [MobileAppController]
    public class PostController : ApiController
    {
        BackendMobileQueueContext context;
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            context = new BackendMobileQueueContext();
        }
        public PostValue Get()
        {
            try
            {
                var ret = Error("DefaultValue");
                var parameters = ControllerContext.Request.GetQueryNameValuePairs();
                var param = parameters.Where(kv => kv.Key == "PostId").ToList();
                if (param.Count==1)
                {
                    var PostId = param.First().Value;
                    if (!string.IsNullOrWhiteSpace(PostId))
                    {
                        var PostOfice = context.Values.FirstOrDefault(v => v.Id == PostId);
                        if (PostOfice != null)
                        {
                            ret = Success(PostOfice);
                        }
                        else
                        {
                            ret = Error("Search value");
                        }
                    }
                    else
                    {
                        ret = Error("Parameters value");
                    }
                }
                else
                {
                    ret = Error("Parameters number");
                }
                return ret;
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }

        private PostValue Success(Value postOfice)
        {
            return new PostValue() { Result = true, ExpectedTime = postOfice.ExpectedTime, StatusQueue = postOfice.StatusQueue, Tendency = postOfice.Tendency };
        }

        private PostValue Error(string info)
        {
            return new PostValue() { Info = info, Result = false };
        }
    }
}