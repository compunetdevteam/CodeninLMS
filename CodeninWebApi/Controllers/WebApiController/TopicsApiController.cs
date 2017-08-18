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
    public class TopicsApiController : ApiController
    {
        private readonly CodenimDbContext _db = new CodenimDbContext();

        // GET: api/TopicsApi
        public IQueryable<Topic> GetTopics()
        {
            return _db.Topics;
        }

        // GET: api/TopicsApi/5
        [ResponseType(typeof(Topic))]
        public async Task<IHttpActionResult> GetTopic(int id)
        {
            Topic topic = await _db.Topics.FindAsync(id);
            if (topic == null)
            {
                return NotFound();
            }

            return Ok(topic);
        }

        // PUT: api/TopicsApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTopic(int id, Topic topic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != topic.TopicId)
            {
                return BadRequest();
            }

            _db.Entry(topic).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TopicExists(id))
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

        // POST: api/TopicsApi
        [ResponseType(typeof(Topic))]
        public async Task<IHttpActionResult> PostTopic(Topic topic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Topics.Add(topic);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = topic.TopicId }, topic);
        }

        // DELETE: api/TopicsApi/5
        [ResponseType(typeof(Topic))]
        public async Task<IHttpActionResult> DeleteTopic(int id)
        {
            Topic topic = await _db.Topics.FindAsync(id);
            if (topic == null)
            {
                return NotFound();
            }

            _db.Topics.Remove(topic);
            await _db.SaveChangesAsync();

            return Ok(topic);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TopicExists(int id)
        {
            return _db.Topics.Count(e => e.TopicId == id) > 0;
        }
    }
}