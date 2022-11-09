using Microsoft.Extensions.Configuration;
using MonitoringChallenge.Model;
using MonitoringChallenge.Repository;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringChallenge.Service
{
    public class VideoFileService : IVideoFileService
    {
        private readonly VideoFileRepository _videoFileRepository;

        public VideoFileService(DatabaseConfig config)
        {
            _videoFileRepository = new VideoFileRepository(config);
        }

        public async Task Add(string serverId, string description, string file)
        {
            await _videoFileRepository.Add(
                new VideoFile() {
                    Id = new Guid(),
                    ServerId = Guid.Parse(serverId),
                    Description = description,
                    File = Convert.FromBase64String(file) });
        }

        public async Task Delete(string serverId, string videoId)
        {
            await _videoFileRepository.Delete(new VideoFile() {ServerId = Guid.Parse(serverId), Id = Guid.Parse(videoId) });
        }

        public async Task<VideoFile> Get(string serverId, string videoId)
        {
            return await _videoFileRepository.Get(new VideoFile() { ServerId = Guid.Parse(serverId), Id = Guid.Parse(videoId) });
        }

        public async Task<IEnumerable<VideoFile>> GetAll(string serverId)
        {
            return await _videoFileRepository.GetAll(new VideoFile() { ServerId = Guid.Parse(serverId) });
        }

        public async Task Recicle(int days)
        {
            await _videoFileRepository.Recicle(new VideoFile() { Created = DateTime.Now.AddDays(-days) });
        }
    }
}
