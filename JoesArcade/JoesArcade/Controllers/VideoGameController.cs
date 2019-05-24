using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JoesArcade.DAL;
using JoesArcade.Models;

namespace JoesArcade.Controllers
{
    public class VideoGameController : Controller
    {
        private ArcadeContext db = new ArcadeContext();

        // GET: VideoGame
        public ActionResult Index()
        {
            return View(db.VideoGames.ToList());
        }

        // GET: VideoGame/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoGame videoGame = db.VideoGames.Find(id);
            if (videoGame == null)
            {
                return HttpNotFound();
            }
            return View(videoGame);
        }

        // GET: VideoGame/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VideoGame/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VideoGameID,Year,Game,Genre,Publisher,OriginalPlatform")] VideoGame videoGame)
        {
            if (ModelState.IsValid)
            {
                db.VideoGames.Add(videoGame);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(videoGame);
        }

        // GET: VideoGame/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoGame videoGame = db.VideoGames.Find(id);
            if (videoGame == null)
            {
                return HttpNotFound();
            }
            return View(videoGame);
        }

        // POST: VideoGame/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VideoGameID,Year,Game,Genre,Publisher,OriginalPlatform")] VideoGame videoGame)
        {
            if (ModelState.IsValid)
            {
                db.Entry(videoGame).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(videoGame);
        }

        // GET: VideoGame/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoGame videoGame = db.VideoGames.Find(id);
            if (videoGame == null)
            {
                return HttpNotFound();
            }
            return View(videoGame);
        }

        // POST: VideoGame/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VideoGame videoGame = db.VideoGames.Find(id);
            db.VideoGames.Remove(videoGame);
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
