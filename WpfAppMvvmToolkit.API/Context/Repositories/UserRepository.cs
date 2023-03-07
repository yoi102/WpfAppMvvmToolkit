

using WpfAppMvvmToolkit.API.Context.Entities;
using WpfAppMvvmToolkit.API.Context.UnitOfWork;

namespace MyToDo.Api.Context.Repository
{
    public class UserRepository : Repository<User>, IRepository<User>
    {
        public UserRepository(MvvmToolkitContext dbContext) : base(dbContext)
        {
        }
    }
}
