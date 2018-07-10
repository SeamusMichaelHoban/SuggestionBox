using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SuggestionBox.Models;

namespace SuggestionBox.Controllers
{
    public class SuggetionModelsController : Controller
    {
        private SuggestionBoxContext db = new SuggestionBoxContext();

        // GET: SuggetionModels
        public ActionResult Index()
        {
            return View(db.SuggetionModels.ToList());
        }

        // GET: SuggetionModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuggetionModel suggetionModel = db.SuggetionModels.Find(id);
            if (suggetionModel == null)
            {
                return HttpNotFound();
            }
            return View(suggetionModel);
        }

        // GET: SuggetionModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuggetionModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecordNum,Topic,Suggestion")] SuggetionModel suggetionModel)
        {
            if (ModelState.IsValid)
            {
                db.SuggetionModels.Add(suggetionModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(suggetionModel);
        }

        // GET: SuggetionModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuggetionModel suggetionModel = db.SuggetionModels.Find(id);
            if (suggetionModel == null)
            {
                return HttpNotFound();
            }
            return View(suggetionModel);
        }

        // POST: SuggetionModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecordNum,Topic,Suggestion")] SuggetionModel suggetionModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suggetionModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(suggetionModel);
        }

        // GET: SuggetionModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuggetionModel suggetionModel = db.SuggetionModels.Find(id);
            if (suggetionModel == null)
            {
                return HttpNotFound();
            }
            return View(suggetionModel);
        }

        // POST: SuggetionModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SuggetionModel suggetionModel = db.SuggetionModels.Find(id);
            db.SuggetionModels.Remove(suggetionModel);
            db.SaveChanges();
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
