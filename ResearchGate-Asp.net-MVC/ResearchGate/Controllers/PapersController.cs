using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ResearchGate.Models;
using System.IO;
using Microsoft.AspNet.Identity;

namespace ResearchGate.Controllers
{
    public class PapersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [Authorize]
        // GET: Papers
        public ActionResult Index()
        {
            //var PostDet =( from comment in db.Comments
            //              join post in db.Papers
            //              on comment.PostID equals post.ID

            //              select new comment
            //              {
                              
            //              }).ToList();


           return View(db.Papers.ToList());
          //  return View(PostDet);

        }
        public PartialViewResult ParComments(int id)
        {
            var comment = db.Comments.Where(c => c.PostID == id);
              return PartialView("_ParComments", comment);

        }
        public PartialViewResult Participators(int id)
        {
            var participators = db.Participators.Where(c => c.PostID == id);
            
            return PartialView("_Participators", participators);

        }
        public ActionResult ParticipatorsPosts(string id)
        {
            
            var check = db.Papers.Where(a => a.UserId == id).ToList();
            return View(check);
        }
        public ActionResult Saerch(string authorName)
        {
            var AuthorName = db.Papers.Where(p => p.Author.StartsWith(authorName));

           return View("Index",AuthorName.ToList());


            
        }
        public ActionResult PostAll(string id)
        {

            //Papers papers = db.Papers.Find(id);
            var check = db.Papers.Where(a => a.UserId == id).ToList();

            return View(check);
        }

        // GET: Papers/Details/5
        public ActionResult Details(string id)
        {
            
            ApplicationUser user = db.Users.Find(id);
            
            return View(user);
        }
        

        // GET: Papers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Papers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Papers papers)
        {
            if (ModelState.IsValid)
            {
                
                var UserId = User.Identity.GetUserId();
                papers.UserId = UserId;
                papers.Post_like = 0;
                papers.Post_Date = DateTime.Now;
                db.Papers.Add(papers);
                db.SaveChanges();
                return RedirectToAction("Index");
                    
                  
            }

            return View(papers);
        }
        
        [HttpGet]
        public ActionResult PostComment(int? id)
        {
            Papers papers = db.Papers.Find(id);
            return View(papers);
        }
        
        
        public ActionResult Like (int id)
        {
            Papers update = db.Papers.ToList().Find(u => u.ID == id);
            update.Post_like +=1;
            db.SaveChanges();
           
            return RedirectToAction("Index");
        }
        public ActionResult DisLike(int id)
        {
            Papers update = db.Papers.ToList().Find(u => u.ID == id);
            update.Post_Dislike += 1;
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        // GET: Papers/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id, Participators participators)
        {
       
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var UserId = User.Identity.GetUserId();
            participators.userId = UserId;
            ApplicationUser user = db.Users.Find(UserId);
            participators.Name = user.FirstName +" "+ user.LastName;
            
            participators.PostID = (int)id;
            db.Participators.Add(participators);
            db.SaveChanges();

            Papers papers = db.Papers.Find(id);
            if (papers == null)
            {
                return HttpNotFound();
            }
            return View(papers);
        }

        // POST: Papers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Title,Author,ResaerchPost")] Papers papers)
        {
            
            if (ModelState.IsValid)
            {
                db.Entry(papers).State = EntityState.Modified;
                
                db.SaveChanges();
                return RedirectToAction("Index","Papers");
            }
            return View(papers);
        }

        // GET: Papers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Papers papers = db.Papers.Find(id);
            if (papers == null)
            {
                return HttpNotFound();
            }
            return View(papers);
        }

        // POST: Papers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Papers papers = db.Papers.Find(id);
            db.Papers.Remove(papers);
            db.SaveChanges();
            return RedirectToAction("MyPosts","Manage");
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
