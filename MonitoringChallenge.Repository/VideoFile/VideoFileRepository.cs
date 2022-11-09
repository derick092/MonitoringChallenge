using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using MonitoringChallenge.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringChallenge.Repository
{
    public class VideoFileRepository : IVideoFileRepository
    {
        private readonly DatabaseConfig _databaseConfig;

        public VideoFileRepository(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }

        public async Task Add(VideoFile videoFile)
        {
            using (var connection = new SqliteConnection(_databaseConfig.Name))
            {
                await connection.InsertAsync<VideoFile>(videoFile);
            }
        }

        public async Task Delete(VideoFile videoFile)
        {
            using (var connection = new SqliteConnection(_databaseConfig.Name))
            {
                await connection.DeleteAsync<VideoFile>(videoFile);
            }
        }

        public async Task<VideoFile> Get(VideoFile videoFile)
        {
            using (var connection = new SqliteConnection(_databaseConfig.Name))
            {
                return await connection.GetAsync<VideoFile>(videoFile);
            }
        }

        public async Task<IEnumerable<VideoFile>> GetAll(VideoFile videoFile)
        {
            var param = new DynamicParameters(new Dictionary<string, object>() { 
                { "@ServerId", videoFile.ServerId } 
            });
            var query = "SELECT * FROM VideoFile WHERE ServerId = @ServerId";

            using (var connection = new SqliteConnection(_databaseConfig.Name))
            {
                return await connection.QueryAsync<VideoFile>(query, param);
            }
        }

        public async Task Recicle(VideoFile videoFile)
        {
            using (var connection = new SqliteConnection(_databaseConfig.Name))
            {
                await connection.DeleteAsync<VideoFile>(videoFile);
            }

            var param = new DynamicParameters(new Dictionary<string, object>() {
                { "@Created", videoFile.Created }
            });
            var query = "DELETE FROM VideoFile WHERE Created <= @Created";

            using (var connection = new SqliteConnection(_databaseConfig.Name))
            {
                await connection.QueryAsync<VideoFile>(query, param);
            }
        }
    }
}
