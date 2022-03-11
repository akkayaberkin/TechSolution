using Tech.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tech.DataAccessLayer.EntityFramework
{
    //public class DatabaseContext : DbContext
    //{
    //    public DbSet<TechUser> TechUsers { get; set; }
    //    public DbSet<Kayit> Notes { get; set; }
    //    public DbSet<Comment> Comments { get; set; }
    //    public DbSet<Category> Categories { get; set; }
    //    public DbSet<Liked> Likes { get; set; }

    //    public DatabaseContext()
    //    {
    //        Database.SetInitializer(new MyInitializer());
    //    }
    //}

    public class DatabaseContext : DbContext
    {
        public DbSet<TechUser> TechUsers { get; set; }
        public DbSet<Kayit> Notes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Urun> Uruns { get; set; }
        public DbSet<UrunGonderilmeDurum> urunGonderilmeDurum { get; set; }

        public DatabaseContext()
        {
            Database.SetInitializer(new MyInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
         
        }
    }
}
