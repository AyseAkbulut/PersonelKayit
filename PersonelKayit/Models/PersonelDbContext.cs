using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace PersonelKayit.Models
{
    public class PersonelDbContext :DbContext
    {
        public PersonelDbContext() : base("PersonelDb")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Personel> Personels { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}