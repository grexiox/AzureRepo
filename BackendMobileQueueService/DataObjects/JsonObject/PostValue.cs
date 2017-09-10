namespace BackendMobileQueueService.DataObjects.JsonObject
{
    public class PostValue
    {
        public int StatusQueue { get; set; }
        public int ExpectedTime { get; set; }
        public bool Tendency { get; set; }
        public bool Result { get; set; }
        public string Info {get;set;}
    }
}