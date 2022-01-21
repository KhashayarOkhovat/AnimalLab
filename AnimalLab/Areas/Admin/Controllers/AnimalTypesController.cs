using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using DataLayer.Context;

namespace AnimalLab.Areas.Admin.Controllers
{
    public class AnimalTypesController : Controller
    {
        //private LabratoryDBEntities db1 = new LabratoryDBEntities();
        UnitOfWork db = new UnitOfWork();

        // GET: Admin/AnimalTypes
        public ActionResult Index()
        {
            return View(db.AnimalType_Repository.Get());
        }

        // GET: Admin/AnimalTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimalType animalType = db.AnimalType_Repository.GetById(id);
            if (animalType == null)
            {
                return HttpNotFound();
            }
            return View(animalType);
        }

        // GET: Admin/AnimalTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AnimalTypeId,AnimalType_Name")] AnimalType animalType)
        {
            if (ModelState.IsValid)
            {
                db.AnimalType_Repository.Insert(animalType);
                db.sava();
                return RedirectToAction("Index");
            }

            return View(animalType);
        }

        // GET: Admin/AnimalTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimalType animalType = db.AnimalType_Repository.GetById(id);
            if (animalType == null)
            {
                return HttpNotFound();
            }
            return View(animalType);
        }

        // POST: Admin/AnimalTypes/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AnimalTypeId,AnimalType_Name")] AnimalType animalType)
        {
            if (ModelState.IsValid)
            {
                db.AnimalType_Repository.Update(animalType);
                db.sava();
                return RedirectToAction("Index");
            }
            return View(animalType);
        }

        // GET: Admin/AnimalTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimalType animalType = db.AnimalType_Repository.GetById(id);
            if (animalType == null)
            {
                return HttpNotFound();
            }
            return View(animalType);
        }

        // POST: Admin/AnimalTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnimalType animalType = db.AnimalType_Repository.GetById(id);
            db.AnimalType_Repository.Delete(animalType);
            db.sava();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
