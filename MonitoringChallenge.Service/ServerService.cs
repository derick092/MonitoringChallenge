using Microsoft.Extensions.Configuration;
using MonitoringChallenge.Model;
using MonitoringChallenge.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringChallenge.Service
{
    public class ServerService : IServerService
    {
        private readonly ServerRepository _serverRepository;

        public ServerService(DatabaseConfig config)
        {
            _serverRepository = new ServerRepository(config);
        }

        public async Task Add(string name, string ipAddress, int port)
        {
            await _serverRepository.Add(
                new Server() 
                {
                    Id = new Guid(), 
                    Name = name, 
                    IPAddress = ipAddress, 
                    Port = port, 
                    Status = true });
        }

        public async Task<bool> CheckConnection(string ipAddress, int port)
        {
            return await _serverRepository.CheckConnection(new Server() { IPAddress = ipAddress, Port = port });
        }

        public async Task<bool> CheckStatus(string serverId)
        {
            return await _serverRepository.CheckStatus(new Server() { Id = Guid.Parse(serverId) });
        }

        public async Task Delete(string serverId)
        {
            await _serverRepository.Delete(new Server() { Id = Guid.Parse(serverId) });
        }

        public async Task<Server> Get(string serverId)
        {
            return await _serverRepository.Get(new Server() { Id = Guid.Parse(serverId) });
        }

        public async Task<IEnumerable<Server>> GetAll()
        {
            return await _serverRepository.GetAll();
        }

        public async Task Update(string serverId, string name, string ipAddress, int port, bool status)
        {
            await _serverRepository.Update(
                new Server()
                {
                    Id = Guid.Parse(serverId),
                    Name = name,
                    IPAddress = ipAddress,
                    Port = port,
                    Status = status
                });
        }
    }
}
