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
    public class PersonController : Controller
    {
        UnitOfWork db = new UnitOfWork();

        // GET: Admin/Person
        public ActionResult Index()
        {
            var person = db.Person_Repository.Get(null,null,"Role");
            return View(person);
        }

        // GET: Admin/Person/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Person_Repository.GetById(id.Value);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: Admin/Person/Create
        public ActionResult Create()
        {
            ViewBag.Person_RoleId = new SelectList(db.Role_Repository.Get(), "RoleId", "Role_Type");
            return View();
        }

        // POST: Admin/Person/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonId,Person_FirstName,Person_LastName,Person_PhoneNumber,Person_RoleId")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Person_Repository.Insert(person);
                db.sava();
                return RedirectToAction("Index");
            }

            ViewBag.Person_RoleId = new SelectList(db.Role_Repository.Get(), "RoleId", "Role_Type", person.Person_RoleId);
            return View(person);
        }

        // GET: Admin/Person/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Person_Repository.GetById(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            ViewBag.Person_RoleId = new SelectList(db.Role_Repository.Get(), "RoleId", "Role_Type", person.Person_RoleId);
            return View(person);
        }

        // POST: Admin/Person/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonId,Person_FirstName,Person_LastName,Person_PhoneNumber,Person_RoleId")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Person_Repository.Update(person);
                db.sava();
                return RedirectToAction("Index");
            }
            ViewBag.Person_RoleId = new SelectList(db.Role_Repository.Get(), "RoleId", "Role_Type", person.Person_RoleId);
            return View(person);
        }

        // GET: Admin/Person/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Person_Repository.GetById(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: Admin/Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.Person_Repository.GetById(id);
            db.Person_Repository.Delete(person);
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
