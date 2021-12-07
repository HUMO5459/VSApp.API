using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSApp.Core.Entities;

namespace VSApp.Infrastructure.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<User> Users { get; private set; }
        public DbSet<Client> Clients { get; private set; }
        public DbSet<Entering> Enterings { get; private set; }
        public DbSet<Exiting> Exitings { get; private set; }
        public DbSet<Server> Servers { get; private set; }
        public DbSet<Camera> Cameras { get; private set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
