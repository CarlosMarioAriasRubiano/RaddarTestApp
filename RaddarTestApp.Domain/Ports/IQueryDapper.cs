namespace RaddarTestApp.Domain.Ports
{
    public interface IQueryDapper
    {
        Task<IEnumerable<T>> QueryAsync<T>(string resourceItemDescription)
            where T : class;

        Task<IEnumerable<T>> QueryAsync<T>(string resourceItemDescription, object parameters)
            where T : class;

        Task<T> QuerySingleAsync<T>(string resourceItemDescription, object parameters)
            where T : class;
    }
}
