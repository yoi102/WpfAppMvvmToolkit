using Microsoft.EntityFrameworkCore;
using WpfAppMvvmToolkit.API.Context.Entities;

namespace WpfAppMvvmToolkit.API.Context
{
    public class MvvmToolkitContext : DbContext
    {

        public MvvmToolkitContext(DbContextOptions<MvvmToolkitContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }





    }
}
