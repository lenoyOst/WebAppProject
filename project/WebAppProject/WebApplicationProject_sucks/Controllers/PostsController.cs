﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationProject_sucks;
using WebApplicationProject_sucks.Models;

namespace WebApplicationProject_sucks.Controllers
{
    public class PostsController : Controller
    {
        private MyDB db = new MyDB();

        // GET: Posts
        public ActionResult Index()
        {
            var posts = db.Posts.Include(p => p.ProfessionalPage);
            return View(posts.ToList());
        }

        // GET: Posts/Details/5
        [UserActivityFilter]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            ViewBag.PageID = new SelectList(db.ProfessionalPages, "ProffesionalPageID", "NameOfPage");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostID,Title,Date,Rating,NumOfRating,Description,PageID,Content")] Post post, string[] selectedOptions)
        {


            if (ModelState.IsValid)
            {
                post.PostID = db.Posts.Count();
                for (int i = 0; i < selectedOptions.Length; i++)
                {//MtM of category-post relationship 

                    db.PostToCategories.Add(new PostToCategory(post.PostID, selectedOptions[i]));
                }


                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(post);
        }


        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateComment(string PostID, string CommentContent, string CommentCreator)
        {
            int commentID = db.PostComments.Count();
            PostComment comment = new PostComment(commentID, Int32.Parse(PostID), CommentContent, CommentCreator, DateTime.Today.Date);
            db.PostComments.Add(comment);
            db.SaveChanges();

            return Redirect("../Posts/Details/" + Int32.Parse(PostID));

        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.PageID = new SelectList(db.ProfessionalPages, "ProffesionalPageID", "NameOfPage", post.PageID);
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostID,Title,Description,Content")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(post);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
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
        [HttpPost]
        public void AddHtmlScript(string content , int id)
        {
            HTMLScript hs = new HTMLScript();
            hs.Content = content;
            //
            Post post = db.Posts.Find(id);
            if (ModelState.IsValid)
            {
                post.Content.Add(hs);
                db.SaveChanges();
            }
        }
    }
}
