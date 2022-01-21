using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using DataLayer.Context;

namespace AnimalLab.Areas.Admin.Controllers
{
    public class TestTypesController : Controller
    {

        UnitOfWork db = new UnitOfWork();
        // GET: Admin/TestTypes
        public ActionResult Index()
        {
            return View(db.TestType_Repository.Get());
        }

        // GET: Admin/TestTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestType testType = db.TestType_Repository.GetById(id.Value);
            if (testType == null)
            {
                return HttpNotFound();
            }
            return View(testType);
        }

        // GET: Admin/TestTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TestTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TestId,TestType_Name")] TestType testType)
        {
            if (ModelState.IsValid)
            {
                db.TestType_Repository.Insert(testType);
                db.sava();
                return RedirectToAction("Index");
            }

            return View(testType);
        }

        // GET: Admin/TestTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestType testType = db.TestType_Repository.GetById(id.Value);
            if (testType == null)
            {
                return HttpNotFound();
            }
            return View(testType);
        }

        // POST: Admin/TestTypes/Edit/5
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TestId,TestType_Name")] TestType testType)
        {
            if (ModelState.IsValid)
            {
                db.TestType_Repository.Update(testType);
                db.sava();
                return RedirectToAction("Index");
            }
            return View(testType);
        }

        // GET: Admin/TestTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestType testType = db.TestType_Repository.GetById(id);
            if (testType == null)
            {
                return HttpNotFound();
            }
            return View(testType);
        }

        // POST: Admin/TestTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestType testType = db.TestType_Repository.GetById(id);
            db.TestType_Repository.Delete(testType);
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
