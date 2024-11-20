using CqrsSample.Framework.MemCache;
using CqrsSample.Framework.Sql;

namespace CqrsSample
{
    public class TraditionalAccountService
    {
        public TraditionalAccountService(IRepository repository, ICacheProvider cacheProvider)
        {
            
        }
        public Guid CreateAccount()
        {
            throw new NotImplementedException();
        }

        public void UpdateAccount()
        {
            throw new NotImplementedException();

        }

        public void DeleteAccount(Guid id)
        {

        }

        public Features.Entities.Account GetAccountById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Features.Entities.Account> SearchAccounts(string searchTerm)
        {
            throw new NotImplementedException();

        }
    }
}
