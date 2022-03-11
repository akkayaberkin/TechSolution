using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Tech.Entities;

namespace Tech.DataAccessLayer.EntityFramework
{
    public class MyInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            // Adding admin user..
            TechUser admin = new TechUser()
            {
                Name = "Berkin",
                Surname = "Akkaya",
                Email = "berkin@berkin.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = true,
                Username = "berkinakkaya",
                ProfileImageFilename = "user_boy.png",
                Password = "123",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUsername = "berkinakkaya"
            };

            // Adding standart user..
            TechUser standartUser = new TechUser()
            {
                Name = "Beko",
                Surname = "Ak",
                Email = "bekoak@gmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = false,
                Username = "bekoak",
                Password = "123",
                ProfileImageFilename = "user_boy.png",
                CreatedOn = DateTime.Now.AddHours(1),
                ModifiedOn = DateTime.Now.AddMinutes(65),
                ModifiedUsername = "bekoak"
            };
            Category cat = new Category()
            {
                Title = "Test - Kategori",
                Description = "Kategori Testi için oluşturulmuştur",
                CreatedOn = DateTime.Now.AddHours(1),
                ModifiedOn = DateTime.Now.AddMinutes(65),
                ModifiedUsername = "bekoak"
            };
            context.Categories.Add(cat);
            cat = new Category()
            {
                Title = "Test - Kategori -2",
                Description = "Kategori - 2 Testi için oluşturulmuştur",
                CreatedOn = DateTime.Now.AddHours(1),
                ModifiedOn = DateTime.Now.AddMinutes(65),
                ModifiedUsername = "berkinakkaya"
            };
            context.Categories.Add(cat);
            Kayit kayit = new Kayit()
            {
               
                Text = "Yazı Metni -1",
                Konu = "Test-1",
                CategoryId = 1,
                Owner = standartUser,
                ImagePath = "/Images/1.jpg",
                CreatedOn = DateTime.Now.AddHours(1),
                ModifiedOn = DateTime.Now.AddMinutes(65),
                ModifiedUsername = "berkinakkaya"
            };
            context.Notes.Add(kayit);
            Kayit note2 = new Kayit()
            {
                
                Text = "Yazı Metni - 2",
                Konu="Test-2",
                CategoryId = 2,
                Owner = admin,
                ImagePath = "/Images/2.jpg",
                CreatedOn = DateTime.Now.AddHours(1),
                ModifiedOn = DateTime.Now.AddMinutes(65),
                ModifiedUsername = "berkinakkaya"
            };
            UrunGonderilmeDurum urunGonderilmeDurum = new UrunGonderilmeDurum()
            {

                Adi = "Success",
                Kodu = "Success",
                CreatedOn = DateTime.Now.AddHours(1),
                ModifiedOn = DateTime.Now.AddMinutes(65),
                ModifiedUsername = "berkinakkaya"
            };
            UrunGonderilmeDurum urunGonderilmeDurum2 = new UrunGonderilmeDurum()
            {

                Adi = "Warning",
                Kodu = "Warning",
                CreatedOn = DateTime.Now.AddHours(1),
                ModifiedOn = DateTime.Now.AddMinutes(65),
                ModifiedUsername = "berkinakkaya"
            };
            UrunGonderilmeDurum urunGonderilmeDurum3 = new UrunGonderilmeDurum()
            {

                Adi = "Danger",
                Kodu = "Danger",
                CreatedOn = DateTime.Now.AddHours(1),
                ModifiedOn = DateTime.Now.AddMinutes(65),
                ModifiedUsername = "berkinakkaya"
            };

            context.Notes.Add(note2);
            context.urunGonderilmeDurum.Add(urunGonderilmeDurum);
            context.urunGonderilmeDurum.Add(urunGonderilmeDurum2);
            context.urunGonderilmeDurum.Add(urunGonderilmeDurum3);
            context.TechUsers.Add(admin);
            context.TechUsers.Add(standartUser);


            context.SaveChanges();
        }
    }
}
