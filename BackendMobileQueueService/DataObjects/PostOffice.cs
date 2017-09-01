using Microsoft.Azure.Mobile.Server;

namespace BackendMobileQueueService.DataObjects
{
    public class PostOffice : EntityData
    {

        //gps
        public State State { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string OpeningHours { get; set; }
        public string City { get; set; }
        public string Url { get; set; }
    }
}