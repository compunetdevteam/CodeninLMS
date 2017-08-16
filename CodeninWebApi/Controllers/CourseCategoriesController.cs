using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeninModel;
using CodeninWebApi.Models;

namespace CodeninWebApi.Controllers
{
    public class CourseCategoriesController : Controller
    {
        private readonly CodenimDbContext _db = new CodenimDbContext();

        // GET: CourseCategories
        public async Task<ActionResult> Index()
        {
            return View(await _db.CourseCategories.ToListAsync());
        }

        // GET: CourseCategories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseCategory courseCategory = await _db.CourseCategories.FindAsync(id);
            if (courseCategory == null)
            {
                return HttpNotFound();
            }
            return View(courseCategory);
        }

        // GET: CourseCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CourseCategoryId,CategoryName")] CourseCategory courseCategory)
        {
            if (ModelState.IsValid)
            {
                _db.CourseCategories.Add(courseCategory);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(courseCategory);
        }

        // GET: CourseCategories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseCategory courseCategory = await _db.CourseCategories.FindAsync(id);
            if (courseCategory == null)
            {
                return HttpNotFound();
            }
            return View(courseCategory);
        }

        // POST: CourseCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CourseCategoryId,CategoryName")] CourseCategory courseCategory)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(courseCategory).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(courseCategory);
        }

        // GET: CourseCategories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseCategory courseCategory = await _db.CourseCategories.FindAsync(id);
            if (courseCategory == null)
            {
                return HttpNotFound();
            }
            return View(courseCategory);
        }

        // POST: CourseCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CourseCategory courseCategory = await _db.CourseCategories.FindAsync(id);
            _db.CourseCategories.Remove(courseCategory);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}