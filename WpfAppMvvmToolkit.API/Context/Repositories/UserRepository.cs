using WpfAppMvvmToolkit.API.Context;
using WpfAppMvvmToolkit.API.Context.Entities;
using WpfAppMvvmToolkit.API.Context.UnitOfWork;

namespace WpfAppMvvmToolkit.API.Context.Repositories
{
    public class UserRepository : Repository<User>, IRepository<User>
    {
        public UserRepository(MvvmToolkitContext dbContext) : base(dbContext)
        {
        }
    }
}
