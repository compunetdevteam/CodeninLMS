using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CodeninModel;
using CodeninWebApi.Models;

namespace CodeninWebApi.Controllers.WebApiController
{
    public class CoursesApiController : ApiController
    {
        private readonly CodenimDbContext _db;

        public CoursesApiController()
        {
            _db = new CodenimDbContext();
        }

        // GET: api/CoursesApi
        public List<Course> GetCourses()
        {
            return _db.Courses.AsNoTracking().Include(c => c.CourseCategory).Include(m => m.Modules).Include(t => t.Modules).ToList();
        }

        // GET: api/CoursesApi/5
        [ResponseType(typeof(Course))]
        public async Task<IHttpActionResult> GetCourse(int id)
        {
            Course course = await _db.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        // PUT: api/CoursesApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCourse(int id, Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != course.CourseId)
            {
                return BadRequest();
            }

            _db.Entry(course).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CoursesApi
        //this method is use to create courses
        [ResponseType(typeof(Course))]
        public async Task<IHttpActionResult> PostCourse(Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Courses.Add(course);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = course.CourseId }, course);
        }

        // DELETE: api/CoursesApi/5
        [ResponseType(typeof(Course))]
        public async Task<IHttpActionResult> DeleteCourse(int id)
        {
            Course course = await _db.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            _db.Courses.Remove(course);
            await _db.SaveChangesAsync();

            return Ok(course);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CourseExists(int id)
        {
            return _db.Courses.Count(e => e.CourseId == id) > 0;
        }
    }
}