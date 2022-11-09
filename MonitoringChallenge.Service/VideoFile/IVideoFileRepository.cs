using MonitoringChallenge.Model;

namespace MonitoringChallenge.Service
{
    public interface IVideoFileService
    {
        Task Add(string serverId, string description, string file);
        Task Delete(string serverId, string videoId);
        Task<IEnumerable<VideoFile>> GetAll(string serverId);
        Task<VideoFile> Get(string serverId, string videoId);
        Task Recicle(int days);
    }
}
