using Microsoft.EntityFrameworkCore;
using PrivacyDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrivacyDb.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Livre> Livres { get; set; }
        //public DbSet<Login> Users { get; set; }
    }
}

