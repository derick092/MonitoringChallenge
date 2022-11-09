namespace MonitoringChallenge.Api.Request
{
    public class AddVideoFileRequest
    {
        public string? ServerId { get; set; }
        public string? Description { get; set; }
        public string? File { get; set; }
    }
}
