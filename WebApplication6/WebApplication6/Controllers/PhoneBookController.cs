using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class PhoneBookController : Controller
    {
        private DBContext db = new DBContext();

        // GET: /PhoneBook/
        public ActionResult Index()
        {

            return View(db.PhoneBooks.ToList());
        }

        // GET: /PhoneBook/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhoneBook phonebook = db.PhoneBooks.Find(id);
            if (phonebook == null)
            {
                return HttpNotFound();
            }
            return View(phonebook);
        }

        // GET: /PhoneBook/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /PhoneBook/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="PhoneBookId,Number,FirstName,LastName,Email,Address,GroupName,DateEntry")] PhoneBook phonebook)
        {
            if (ModelState.IsValid)
            {
                db.PhoneBooks.Add(phonebook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phonebook);
        }

        // GET: /PhoneBook/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhoneBook phonebook = db.PhoneBooks.Find(id);
            if (phonebook == null)
            {
                return HttpNotFound();
            }
            return View(phonebook);
        }

        // POST: /PhoneBook/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="PhoneBookId,Number,FirstName,LastName,Email,Address,GroupName,DateEntry")] PhoneBook phonebook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phonebook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phonebook);
        }

        // GET: /PhoneBook/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhoneBook phonebook = db.PhoneBooks.Find(id);
            if (phonebook == null)
            {
                return HttpNotFound();
            }
            return View(phonebook);
        }

        // POST: /PhoneBook/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhoneBook phonebook = db.PhoneBooks.Find(id);
            db.PhoneBooks.Remove(phonebook);
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
