﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SomaliaNews.Models;
using System.IO;

namespace SomaliaNews.Controllers
{
    public class NewsController : Controller
    {
        private NewsDbContext db = new NewsDbContext();

        // GET: News
        public ActionResult Index()
        {
            return View(db.News.ToList());
        }

        // GET: News/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // GET: News/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,NewsContext,Image,Side,NewsReporter")] News news, HttpPostedFileBase[] uploadImage)
        {
            if (ModelState.IsValid)
            {
                if (uploadImage != null)
                {
                    foreach (var image in uploadImage)
                    {
                        if (image.ContentLength > 0)
                        {
                            byte[] imageByte = null;
                            using (var binaryImage = new BinaryReader(image.InputStream))
                            {
                                imageByte = binaryImage.ReadBytes(image.ContentLength);
                            }

                            news.Image = imageByte;
                        }
                    }
                }
                news.NewsDate = DateTime.Now;
                db.News.Add(news);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(news);
        }

        // GET: News/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,NewsContext,Image,Side,NewsReporter")] News news, HttpPostedFileBase[] uploadImage)
        {
            if (ModelState.IsValid)
            {
                if (uploadImage != null)
                {
                    foreach (var image in uploadImage)
                    {
                        if (image.ContentLength > 0)
                        {
                            byte[] imageByte = null;
                            using (var binaryImage = new BinaryReader(image.InputStream))
                            {
                                imageByte = binaryImage.ReadBytes(image.ContentLength);
                            }

                            news.Image = imageByte;
                        }
                    }
                }
                news.NewsDate = DateTime.Now;
                db.Entry(news).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(news);
        }

        // GET: News/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = db.News.Find(id);
            db.News.Remove(news);
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
