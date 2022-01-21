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
    public class AnimalsController : Controller
    {
        UnitOfWork db = new UnitOfWork();

        // GET: Admin/Animals
        public ActionResult Index()
        {
            var animal = db.Animal_Repository.Get(null,null, "AnimalType,Person,TestType");
            return View(animal);
        }

        // GET: Admin/Animals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animal_Repository.GetById(id.Value);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // GET: Admin/Animals/Create
        public ActionResult Create()
        {
            ViewBag.Animal_AnimalTypeId = new SelectList(db.AnimalType_Repository.Get(null,null,"Animal"), "AnimalTypeId", "AnimalType_Name");
            ViewBag.Animal_PersonId = new SelectList(db.Person_Repository.Get(null,null,"Animal"), "PersonId", "Person_FirstName");
            ViewBag.Animal_TestId = new SelectList(db.TestType_Repository.Get(null,null,"Animal"), "TestId", "TestType_Name");
            return View();
        }

        // POST: Admin/Animals/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AnimalId,Animal_FullName,Animal_Number,Animal_PersonId,Animal_TestId,Animal_AnimalTypeId")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                db.Animal_Repository.Insert(animal);
                db.sava();
                return RedirectToAction("Index");
            }

            ViewBag.Animal_AnimalTypeId = new SelectList(db.AnimalType_Repository.Get(null, null, "Person"), "AnimalTypeId", "AnimalType_Name", animal.Animal_AnimalTypeId);
            ViewBag.Animal_PersonId = new SelectList(db.Person_Repository.Get(null, null, "Person"), "PersonId", "Person_FirstName", animal.Animal_PersonId);
            ViewBag.Animal_TestId = new SelectList(db.TestType_Repository.Get(null, null, "Person"), "TestId", "TestType_Name", animal.Animal_TestId);
            return View(animal);
        }

        // GET: Admin/Animals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animal_Repository.GetById(id.Value);
            if (animal == null)
            {
                return HttpNotFound();
            }
            ViewBag.Animal_AnimalTypeId = new SelectList(db.AnimalType_Repository.Get(null,null,"Animal"), "AnimalTypeId", "AnimalType_Name", animal.Animal_AnimalTypeId);
            ViewBag.Animal_PersonId = new SelectList(db.Person_Repository.Get(null,null,"Animal"), "PersonId", "Person_FirstName", animal.Animal_PersonId);
            ViewBag.Animal_TestId = new SelectList(db.TestType_Repository.Get(null,null,"Animal"), "TestId", "TestType_Name", animal.Animal_TestId);
            return View(animal);
        }

        // POST: Admin/Animals/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AnimalId,Animal_FullName,Animal_Number,Animal_PersonId,Animal_TestId,Animal_AnimalTypeId")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                db.Animal_Repository.Update(animal);
                db.sava();
                return RedirectToAction("Index");
            }
            ViewBag.Animal_AnimalTypeId = new SelectList(db.AnimalType_Repository.Get(null, null, "Animal"), "AnimalTypeId", "AnimalType_Name", animal.Animal_AnimalTypeId);
            ViewBag.Animal_PersonId = new SelectList(db.Person_Repository.Get(null, null, "Animal"), "PersonId", "Person_FirstName", animal.Animal_PersonId);
            ViewBag.Animal_TestId = new SelectList(db.TestType_Repository.Get(null, null, "Animal"), "TestId", "TestType_Name", animal.Animal_TestId);
            return View(animal);
        }

        // GET: Admin/Animals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animal_Repository.GetById(id.Value);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // POST: Admin/Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Animal animal = db.Animal_Repository.GetById(id);
            db.Animal_Repository.Delete(animal);
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
