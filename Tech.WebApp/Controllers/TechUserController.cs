using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tech.Entities;
using Tech.BusinessLayer;
using Tech.BusinessLayer.Results;
using Tech.WebApp.Filters;
using Tech.WebApp.Models;
using Tech.Entities.Messages;

namespace Tech.WebApp.Controllers
{
    [Auth]
    [AuthAdmin]
    [Exc]
    public class TechUserController : Controller
    {
        private TechUserManager TechUserManager = new TechUserManager();


        public ActionResult Index()
        {
            return View(TechUserManager.List());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TechUser TechUser = TechUserManager.Find(x => x.Id == id.Value);

            if (TechUser == null)
            {
                return HttpNotFound();
            }

            return View(TechUser);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TechUser TechUser)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");

            if (ModelState.IsValid)
            {
                BusinessLayerResult<TechUser> res = TechUserManager.Insert(TechUser);

                if(res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View(TechUser);
                }

                return RedirectToAction("Index");
            }

            return View(TechUser);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TechUser TechUser = TechUserManager.Find(x => x.Id == id.Value);

            if (TechUser == null)
            {
                return HttpNotFound();
            }

            return View(TechUser);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TechUser TechUser)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");

            if (ModelState.IsValid)
            {
                BusinessLayerResult<TechUser> res = TechUserManager.Update(TechUser);

                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View(TechUser);
                }

                return RedirectToAction("Index");
            }
            return View(TechUser);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TechUser TechUser = TechUserManager.Find(x => x.Id == id.Value);

            if (TechUser == null)
            {
                return HttpNotFound();
            }

            return View(TechUser);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BusinessLayerResult<TechUser> res = new BusinessLayerResult<TechUser>();

            TechUser TechUser = TechUserManager.Find(x => x.Id == id);
            if (TechUser.Id == CurrentSession.User.Id)
            {
                res.AddError(ErrorMessageCode.UserCouldNotRemove, "Kullanıcı silinemez.");
                return RedirectToAction("Index");
            }
            TechUserManager.Delete(TechUser);

            return RedirectToAction("Index");
        }
    }
}
