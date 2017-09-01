using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendMobileQueueService.DataObjects
{
    public class State :EntityData
    {
        public string StateName { get; set; }
        public ICollection<PostOffice> GetPostOffices { get; set; }
    }
}