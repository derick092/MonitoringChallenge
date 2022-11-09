namespace MonitoringChallenge.Api.Request
{
    public class AddServerRequest
    {
        public string? Name { get; set; }
        public string? IPAddress { get; set; }
        public int Port { get; set; }
    }
}
