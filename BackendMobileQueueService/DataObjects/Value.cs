using Microsoft.Azure.Mobile.Server;

namespace BackendMobileQueueService.DataObjects
{
    public class Value : EntityData
    {
        public int StatusQueue { get; set; }
        public string Url { get; set; }
        public int ExpectedTime { get; set; }
        public bool Tendency { get; set; }
        public string History { get; set; }
    }
}