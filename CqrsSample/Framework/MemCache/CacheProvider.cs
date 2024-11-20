namespace CqrsSample.Framework.MemCache
{
    public interface ICacheProvider
    {
        Task<List<T>> Query<T>(string searchTerm);
    }
    public class CacheProvider : ICacheProvider
    {
        public Task<List<T>> Query<T>(string searchTerm)
        {
            throw new NotImplementedException();
        }
    }
}
