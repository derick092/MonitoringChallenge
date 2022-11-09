using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonitoringChallenge.Model;
using System.Collections.Generic;
using System;
using MonitoringChallenge.Service;
using System.Buffers.Text;
using MonitoringChallenge.Api.Request;

namespace MonitoringChallenge.Api.Controllers
{
    [ApiController]
    public class MonitoringController : ControllerBase
    {
        private readonly ServerService _serverService;
        private readonly VideoFileService _videoFileService;

        public MonitoringController(ServerService serverService, VideoFileService videoFileService)
        {
            _serverService = serverService;
            _videoFileService = videoFileService;
        }

        [HttpPost]
        [Route("server")]
        public async Task AddServer(AddServerRequest request)
        {
            await _serverService.Add(request.Name, request.IPAddress, request.Port);
        }

        [HttpDelete]
        [Route("servers/{serverId}")]
        public async Task DeleteServer(string serverId)
        {
            await _serverService.Delete(serverId);
        }

        [HttpGet]
        [Route("servers/{serverId}")]
        public async Task<Server> GetServer(string serverId)
        {
            return await _serverService.Get(serverId);
        }

        [HttpGet]
        [Route("servers/available/{serverId}​")]
        public async Task<bool> CheckStatus(string serverId) 
        {
            return await _serverService.CheckStatus(serverId);
        }

        [HttpGet]
        [Route("servers")]
        public async Task<IEnumerable<Server>> GetAllServers()
        {
            return await _serverService.GetAll();
        }

        [HttpPost]
        [Route("api/servers/{serverId}/videos​")]
        public async Task AddVideoFile(AddVideoFileRequest request)
        {
            await _videoFileService.Add(request.ServerId, request.Description, request.File);
        }

        [HttpDelete]
        [Route("api/servers/{serverId}/videos​/{videoId}")]
        public async Task DeleteVideoFile(string serverId, string videoId)
        {
            await _videoFileService.Delete(serverId, videoId);
        }

        [HttpGet]
        [Route("api/servers/{serverId}/videos​/{videoId}")]
        public async Task<VideoFile> GetVideoFile(string serverId, string videoId)
        {
            return await _videoFileService.Get(serverId,videoId);
        }

        [HttpGet]
        [Route("api/servers/{serverId}/videos​")]
        public async Task<IEnumerable<VideoFile>> GetAllVideoFile(string serverId)
        {
            return await _videoFileService.GetAll(serverId);
        }

        [HttpDelete]
        [Route("api/recycler/process/{days}​")]
        public async Task RecicleVideoFile(int days)
        {
            await _videoFileService.Recicle(days);
        }
    }
}
