using Microsoft.EntityFrameworkCore;
using MultiDB.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiDB.Database
{
    public interface IApplicationDBContext
    {
        DbSet<Profile> Profiles { get; set; }
        int SaveChanges();
    }
}
