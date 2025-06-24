using Dapper;
using RaddarTestApp.Domain.Ports;
using System.ComponentModel;
using System.Data;
using System.Globalization;

namespace RaddarTestApp.Infrastructure.Adapters
{
    public class QueryDapper(IDbConnection connection) : IQueryDapper
    {
        private readonly IDbConnection _connection = connection;
        private readonly ComponentResourceManager _componentResourceManager = new(typeof(Constants.QueryConstants));

        public async Task<IEnumerable<T>> QueryAsync<T>(string resourceItemDescription) where T : class
        {
            string query = GetQuery(resourceItemDescription);

            return await _connection.QueryAsync<T>(query);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string resourceItemDescription, object parameters) where T : class
        {
            string query = GetQuery(resourceItemDescription);

            return await _connection.QueryAsync<T>(query, parameters);
        }

        public async Task<T> QuerySingleAsync<T>(string resourceItemDescription, object parameters) where T : class
        {
            string query = GetQuery(resourceItemDescription);

            return await _connection.QuerySingleOrDefaultAsync<T>(query, parameters);
        }

        private string GetQuery(string resourceItemDescription)
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                _componentResourceManager.GetString(resourceItemDescription)!
            );
        }
    }
}
