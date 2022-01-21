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
    public class ResultController : Controller
    {
        UnitOfWork db = new UnitOfWork();
        // GET: Admin/Result
        public ActionResult Index()
        {
            var result = db.Result_Repository.Get(null,null,"Animal");
            return View(result);
        }

        // GET: Admin/Result/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Result result = db.Result_Repository.GetById(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        // GET: Admin/Result/Create
        public ActionResult Create()
        {
            ViewBag.Result_Animal_Id = new SelectList(db.Animal_Repository.Get(), "AnimalId", "Animal_FullName");
            return View();
        }

        // POST: Admin/Result/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Result_Description,Result_Animal_Id")] Result result)
        {
            if (ModelState.IsValid)
            {
                db.Result_Repository.Insert(result);
                db.sava();
                return RedirectToAction("Index");
            }

            ViewBag.Result_Animal_Id = new SelectList(db.Animal_Repository.Get(), "AnimalId", "Animal_FullName", result.Result_Animal_Id);
            return View(result);
        }

        // GET: Admin/Result/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Result result = db.Result_Repository.GetById(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            ViewBag.Result_Animal_Id = new SelectList(db.Animal_Repository.Get(), "AnimalId", "Animal_FullName", result.Result_Animal_Id);
            return View(result);
        }

        // POST: Admin/Result/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Result_Description,Result_Animal_Id")] Result result)
        {
            if (ModelState.IsValid)
            {
                db.Result_Repository.Update(result);
                db.sava();
                return RedirectToAction("Index");
            }
            ViewBag.Result_Animal_Id = new SelectList(db.Animal_Repository.Get(), "AnimalId", "Animal_FullName", result.Result_Animal_Id);
            return View(result);
        }

        // GET: Admin/Result/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Result result = db.Result_Repository.GetById(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        // POST: Admin/Result/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Result result = db.Result_Repository.GetById(id);
            db.Result_Repository.Delete(result);
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
