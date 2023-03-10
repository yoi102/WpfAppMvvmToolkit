using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using WpfAppMvvmToolkit.API.Context.Entities;

namespace WpfAppMvvmToolkit.API.Context
{
    public class MvvmToolkitContext : DbContext
    {
        public MvvmToolkitContext(DbContextOptions<MvvmToolkitContext> options) : base(options)
        {
        }

        public DbSet<Memo> Memos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profile { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //关系表
            modelBuilder.Entity<User>()
            .HasMany(b => b.Memos)
            .WithOne(i=>i.User)
            . HasForeignKey(b => b.UserId);

            modelBuilder.Entity<User>()
            .HasOne(b => b.Profile)
            .WithOne(i => i.User)
            .HasForeignKey<Profile>(b => b.UserId);
        }
    }
}