using Microsoft.EntityFrameworkCore;
using SuperoTasks.WebAPICore.Data.Mapping;
using SuperoTasks.WebAPICore.Domain;
using System;
using System.IO;

namespace SuperoTasks.WebAPICore.Data.Context
{
    class SuperoTasksContext : DbContext
    {
        public DbSet<Board> Boards { get; set; }
        public DbSet<Card> Cards { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer($@"data source=(localdb)\MSSQLLocalDB;attachdbfilename={MDF_Directory}\SuperoTasks_DATA.mdf;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
                //optionsBuilder.UseSqlServer(@"Data Source=(localdb)\\MSSQLLocalDb;attachdbfilename=|DataDirectory|\SuperoTasks_DATA.mdf;User ID=sa;Password=becomex;Database=Database");
            }
        }
        public static string MDF_Directory
        {
            get
            {
                var directoryPath = AppDomain.CurrentDomain.BaseDirectory;
                return Path.GetFullPath(Path.Combine(directoryPath, "..//..//..//..//SuperoTasks.WebAPICore.Data//App_Data"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Board>(new BoardMap().Configure);
            modelBuilder.Entity<Card>(new CardMap().Configure);

        }
    }
}

