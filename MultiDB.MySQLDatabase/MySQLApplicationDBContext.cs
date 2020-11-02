using Microsoft.EntityFrameworkCore;
using MultiDB.DatabaseModels;
using System;

namespace MultiDB.MySQLDatabase
{
    public class MySQLApplicationDBContext : DbContext, IMySQLApplicationDBContext
    {
        public MySQLApplicationDBContext(DbContextOptions<MySQLApplicationDBContext> opt) : base(opt)
        { }
        public DbSet<Profile> Profiles { get; set; }
    }
}
