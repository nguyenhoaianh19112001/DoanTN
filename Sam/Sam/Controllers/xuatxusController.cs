using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Sam.Models;

namespace Sam.Controllers
{
    public class xuatxusController : ApiController
    {
        private Model1 db = new Model1();

        // GET: xuatxus
        public IQueryable<xuatxu> Getxuatxus()
        {
            return db.xuatxus;
        }


        // GET: xuatxus/Details/5

        [ResponseType(typeof(xuatxu))]
        public IHttpActionResult Getxuatxu(int? id)
        {
            xuatxu xuatxu = db.xuatxus.Find(id);
            if (xuatxu is null)
            {
                return NotFound();
            }

            return Ok(xuatxu);
        }


        // PUT: api/xuatxus/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putxuatxu(int id, xuatxu xuatxu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != xuatxu.maxuatxu)
            {
                return BadRequest();
            }

            db.Entry(xuatxu).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!xuatxuExists(id))
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

        // POST: api/xuatxus
        [ResponseType(typeof(xuatxu))]
        public IHttpActionResult Postxuatxu(xuatxu xuatxu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.xuatxus.Add(xuatxu);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = xuatxu.maxuatxu }, xuatxu);
        }

        // DELETE: api/xuatxus/5
        [ResponseType(typeof(xuatxu))]
        public IHttpActionResult Deletexuatxu(int id)
        {
            xuatxu xuatxu = db.xuatxus.Find(id);
            if (xuatxu == null)
            {
                return NotFound();
            }

            db.xuatxus.Remove(xuatxu);
            db.SaveChanges();

            return Ok(xuatxu);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool xuatxuExists(int id)
        {
            return db.xuatxus.Count(e => e.maxuatxu == id) > 0;
        }
    }
}
