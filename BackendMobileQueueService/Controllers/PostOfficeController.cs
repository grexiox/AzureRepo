﻿using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using DbAccess.DataObjects;
using DbAccess;

namespace BackendMobileQueueService.Controllers
{
    public class PostOfficeController : TableController<PostOffice>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            BackendMobileQueueContext context = new BackendMobileQueueContext();
            DomainManager = new EntityDomainManager<PostOffice>(context, Request);
        }

        // GET tables/PostOffice
        public IQueryable<PostOffice> GetAllPostOffices()
        {
            return Query();
        }

        // GET tables/PostOffice/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<PostOffice> GetPostOffice(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/PostOffice/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<PostOffice> PatchPostOffice(string id, Delta<PostOffice> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/PostOffice
        public async Task<IHttpActionResult> PostOffice(PostOffice item)
        {
            PostOffice current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/PostOffice/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeletePostOffice(string id)
        {
            return DeleteAsync(id);
        }
    }
}