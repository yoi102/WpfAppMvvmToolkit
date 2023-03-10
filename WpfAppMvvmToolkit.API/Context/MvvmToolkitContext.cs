﻿using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using WpfAppMvvmToolkit.API.Context.Entities;

namespace WpfAppMvvmToolkit.API.Context
{
    public class MvvmToolkitContext : DbContext
    {
        public MvvmToolkitContext(DbContextOptions<MvvmToolkitContext> options) : base(options)
        {
        }

        public DbSet<UserData> UserData { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //关系表
            modelBuilder.Entity<User>()
            .HasMany(b => b.UserData)
            .WithOne(i=>i.User)
            . HasForeignKey(b => b.UserId);
        }
    }
}