namespace WebApp24I.AppCore.Entities
{
    public class Message
    {
        public string ExchangeName { get; set; }
        public string RoutingKey { get; set; }
        public object Data { get; set; }
    }
}
