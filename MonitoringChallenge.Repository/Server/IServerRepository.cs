using MonitoringChallenge.Model;

namespace MonitoringChallenge.Repository
{
    public interface IServerRepository
    {
        Task Add(Server server);
        Task Update(Server server);
        Task Delete(Server server);
        Task<IEnumerable<Server>> GetAll();
        Task<Server> Get(Server server);
        Task<bool> CheckStatus(Server server);
        Task<bool> CheckConnection(Server server);
    }
}
