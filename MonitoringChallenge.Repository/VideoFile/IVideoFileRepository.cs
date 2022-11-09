using MonitoringChallenge.Model;

namespace MonitoringChallenge.Repository
{
    public interface IVideoFileRepository
    {
        Task Add(VideoFile videoFile);
        Task Delete(VideoFile videoFile);
        Task<IEnumerable<VideoFile>> GetAll(VideoFile videoFile);
        Task<VideoFile> Get(VideoFile videoFile);
        Task Recicle(VideoFile videoFile);
    }
}
