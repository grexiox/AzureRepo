using Newtonsoft.Json;

namespace BackendMobileQueueService.DataObjects.JsonObject
{
    public class PostValue
    {
        [JsonProperty]
        public int StatusQueue { get; set; }
        [JsonProperty]
        public int ExpectedTime { get; set; }
        [JsonProperty]
        public bool Tendency { get; set; }
        [JsonProperty]
        public bool Result { get; set; }
        [JsonProperty]
        public string Info {get;set;}
    }
}