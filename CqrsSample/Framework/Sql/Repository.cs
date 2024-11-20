namespace CqrsSample.Framework.Sql
{
    public interface IRepository
    {
        Task<T> Save<T>(T entity) where T : new();
        Task Delete(Guid id);
        Task<T> GetById<T>(Guid id) where T : new();
    }
    public class Repository : IRepository
    {
        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById<T>(Guid id) where T : new()
        {
            return Task.FromResult(new T());
        }

        public Task<T> Save<T>(T entity) where T : new()
        {
            return Task.FromResult(new T());
        }
    }
}
