using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SecurityDevelopment.Models;
using Microsoft.Extensions.Configuration;

namespace SecurityDevelopment
{
    public class ApplicationContext : DbContext
    {

        public DbSet<Person> Persons { get; set; }
        public DbSet<DebetCard> DebetCards { get; set; }

        public ApplicationContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID = postgres; Password = postgres; Host = localhost; Port = 5435; Database = SecurityDevelopment;");
        }
       
    }

    

}
