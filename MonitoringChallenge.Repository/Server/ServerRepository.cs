using Dapper.Contrib.Extensions;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using MonitoringChallenge.Model;

namespace MonitoringChallenge.Repository
{
    public class ServerRepository : IServerRepository
    {
        private readonly DatabaseConfig _databaseConfig;

        public ServerRepository(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }

        public async Task Add(Server server)
        {
            using (var connection = new SqliteConnection(_databaseConfig.Name))
            {
                await connection.InsertAsync<Server>(server);
            }
        }

        public async Task<bool> CheckConnection(Server server)
        {
            using (var connection = new SqliteConnection(_databaseConfig.Name))
            {
               var result =  await connection.GetAsync<Server>(server);

                return result is not null;
            }
        }

        public async Task<bool> CheckStatus(Server server)
        {
            using (var connection = new SqliteConnection(_databaseConfig.Name))
            {
                var result = await connection.GetAsync<Server>(server);

                return result is not null;
            }
        }

        public async Task Delete(Server server)
        {
            using (var connection = new SqliteConnection(_databaseConfig.Name))
            {
                await connection.DeleteAsync<Server>(server);
            }
        }

        public async Task<Server> Get(Server server)
        {
            using (var connection = new SqliteConnection(_databaseConfig.Name))
            {
                return await connection.GetAsync<Server>(server);
            }
        }

        public async Task<IEnumerable<Server>> GetAll()
        {
            using (var connection = new SqliteConnection(_databaseConfig.Name))
            {
                return await connection.GetAllAsync<Server>();
            }
        }

        public async Task Update(Server server)
        {
            using (var connection = new SqliteConnection(_databaseConfig.Name))
            {
                 await connection.UpdateAsync<Server>(server);
            }
        }
    }
}
