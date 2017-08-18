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
    public class ModulesApiController : ApiController
    {
        private readonly CodenimDbContext _db = new CodenimDbContext();

        // GET: api/ModulesApi
        public IQueryable<Module> GetModules()
        {
            return _db.Modules;
        }

        // GET: api/ModulesApi/5
        [ResponseType(typeof(Module))]
        public async Task<IHttpActionResult> GetModule(int id)
        {
            Module module = await _db.Modules.FindAsync(id);
            if (module == null)
            {
                return NotFound();
            }

            return Ok(module);
        }

        // PUT: api/ModulesApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutModule(int id, Module module)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != module.ModuleId)
            {
                return BadRequest();
            }

            _db.Entry(module).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModuleExists(id))
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

        // POST: api/ModulesApi
        [ResponseType(typeof(Module))]
        public async Task<IHttpActionResult> PostModule(Module module)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Modules.Add(module);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = module.ModuleId }, module);
        }

        // DELETE: api/ModulesApi/5
        [ResponseType(typeof(Module))]
        public async Task<IHttpActionResult> DeleteModule(int id)
        {
            Module module = await _db.Modules.FindAsync(id);
            if (module == null)
            {
                return NotFound();
            }

            _db.Modules.Remove(module);
            await _db.SaveChangesAsync();

            return Ok(module);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ModuleExists(int id)
        {
            return _db.Modules.Count(e => e.ModuleId == id) > 0;
        }
    }
}