using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tech.Entities;
using Tech.WebApp.Models;
using Tech.BusinessLayer;
using Tech.WebApp.Filters;
using System.IO;

namespace Tech.WebApp.Controllers
{
    [Exc]
    public class KayitController : Controller
    {
        private KayitManager kayitManager = new KayitManager();
        private UrunManager urunManager = new UrunManager();
        private CategoryManager categoryManager = new CategoryManager();
        private UrunDurumManager urunDurumManager = new UrunDurumManager();

        //[Auth]
        //public ActionResult Index()
        //{
        //    var notes = kayitManager.ListQueryable().Include("Category").Include("Owner").Where(
        //        x => x.Owner.Id == CurrentSession.User.Id).OrderByDescending(
        //        x => x.ModifiedOn);

        //    return View(notes.ToList());
        //}

        [Auth]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kayit kayit = kayitManager.Find(x => x.Id == id);
            if (kayit == null)
            {
                return HttpNotFound();
            }
            return View(kayit);
        }

        [Auth]
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(CacheHelper.GetCategoriesFromCache(), "Id", "Title");
            return View();
        }

        [Auth]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Urun urun, HttpPostedFileBase NoteImage)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");
            if (NoteImage != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(NoteImage.FileName);
                string extension = Path.GetExtension(NoteImage.FileName);
                fileName = fileName + DateTime.Now.ToString("dd.mm.yyyy") + extension;
                urun.ImagePath = "/Images/" + fileName;
                if (Directory.Exists(Server.MapPath("/Images")) == false)
                    Directory.CreateDirectory(Server.MapPath("/Images"));
                fileName = Path.Combine(Server.MapPath("/Images/"), fileName);
                NoteImage.SaveAs(fileName);
            }
            if (ModelState.IsValid)
            {
                urun.Owner = CurrentSession.User;
                urunManager.Insert(urun);
                return RedirectToAction("Index", "Home");
            }

            //ViewBag.CategoryId = new SelectList(CacheHelper.GetCategoriesFromCache(), "Id", "Title", urun.CategoryId);
            return View(urun);
        }

        [Auth]
        public ActionResult EditState()
        {

            List<Urun> kayitListe = urunManager.ListQueryable().ToList();
            Urun kayit = new Urun();
            if (kayit == null)
            {
                return HttpNotFound();
            }
            UrunDurumManager udm = new UrunDurumManager();

            List<UrunGonderilmeDurum> udmListe = udm.ListQueryable().ToList();

            ViewBag.durumId = new SelectList(udm.ListQueryable().ToList(), "Id", "Adi");
            return View(kayitListe);
        }

        [Auth]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditState(Urun urun)
        {
            return View(urun);
        }
        [Auth]
        [HttpPost]
        public ActionResult TumunuGuncelleUrunDurum(string[] arr, List<string> trId)
        {
            List<Urun> urunlist = urunManager.List();
            UrunGonderilmeDurum urunDurumBasarili = urunDurumManager.Find(o => o.Kodu == "Success");
            UrunGonderilmeDurum urunDurumBeklemede = urunDurumManager.Find(o => o.Kodu == "Warning");
            UrunGonderilmeDurum urunDurumBasarisiz = urunDurumManager.Find(o => o.Kodu == "Danger");
            for (int i = 0; i < trId.Count; i++)
            {
                if (!string.IsNullOrEmpty(arr[i]) || !string.IsNullOrEmpty(trId[i]))
                {
                    Urun urun = urunlist.Where(o => o.Id == Convert.ToInt32(trId[i])).FirstOrDefault();
                    if (urunDurumBasarili.Id == Convert.ToInt32(arr[i]))
                    {
                        urun.Durum = urunDurumBasarili.Kodu;
                    }
                    else if (urunDurumBeklemede.Id == Convert.ToInt32(arr[i]))
                    {
                        urun.Durum = urunDurumBeklemede.Kodu;
                    }
                    else
                    {
                        urun.Durum = urunDurumBasarisiz.Kodu;
                    }
                    urunManager.Save();
                }
            }

            return View();
        }
        [Auth]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kayit kayit = kayitManager.Find(x => x.Id == id);
            if (kayit == null)
            {
                return HttpNotFound();
            }
            return View(kayit);
        }

        [Auth]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kayit kayit = kayitManager.Find(x => x.Id == id);
            kayitManager.Delete(kayit);
            return RedirectToAction("Index");
        }





        public ActionResult UrunDetayGetir(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Urun urun = urunManager.Find(x => x.Id == id);

            if (urun == null || urun.Owner == null)
            {
                return HttpNotFound();
            }

            return PartialView("_PartialUrunDetay", urun);
        }

    }
}
