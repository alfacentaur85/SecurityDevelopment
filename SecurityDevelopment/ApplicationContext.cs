using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SecurityDevelopment.Models;
using Microsoft.Extensions.Configuration;
using Secutrity;

namespace SecurityDevelopment
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Person> Persons { get; set; }

        public DbSet<DebetCard> DebetCards { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
       
    }

    

}
