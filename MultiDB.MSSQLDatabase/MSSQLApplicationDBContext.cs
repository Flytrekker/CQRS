using Microsoft.EntityFrameworkCore;
using MultiDB.DatabaseModels;
using System;

namespace MultiDB.MSSQLDatabase
{
    public class MSSQLApplicationDBContext : DbContext, IMSSQLApplicationDBContext
    {
        public MSSQLApplicationDBContext(DbContextOptions<MSSQLApplicationDBContext> opt) : base(opt)
        {
        }
        public DbSet<Profile> Profiles { get; set; }

    }
}
