using Microsoft.EntityFrameworkCore;
using PrivacyDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrivacyDb.Data
{
    public class DataContext1 : DbContext
    {
        public DataContext1(DbContextOptions<DataContext1> options) : base(options)
        {

        }
        public DbSet<Login> users{ get; set; }
    }
}
