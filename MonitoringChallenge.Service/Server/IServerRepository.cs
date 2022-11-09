using MonitoringChallenge.Model;

namespace MonitoringChallenge.Service
{
    public interface IServerService
    {
        Task Add(string name, string ipAddress, int port);
        Task Update(string id, string name, string ipAddress, int port, bool status);
        Task Delete(string serverId);
        Task<IEnumerable<Server>> GetAll();
        Task<Server> Get(string serverId);
        Task<bool> CheckStatus(string serverId);
        Task<bool> CheckConnection(string ipAddress, int port);
    }
}
