using CRUDUsersAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDUsersAPI.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
            => optionsBuilder.UseSqlite("DataSource=Database.db;Cache=Shared;");


    }
}
