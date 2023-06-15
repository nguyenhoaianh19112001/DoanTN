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
    public class thuonghieusController : ApiController
    {
        private Model1 db = new Model1();

        // GET: thuonghieux
        public IQueryable<thuonghieu> Getthuonghieus()
        {
            return db.thuonghieus;
        }


        // GET: thuonghieus/Details/5

        [ResponseType(typeof(thuonghieu))]
        public IHttpActionResult Getthuonghieu(int? id)
        {
            thuonghieu thuonghieu = db.thuonghieus.Find(id);
            if (thuonghieu is null)
            {
                return NotFound();
            }

            return Ok(thuonghieu);
        }


        // PUT: api/thuonghieus/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putthuonghieu(int id, thuonghieu thuonghieu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != thuonghieu.mathuonghieu)
            {
                return BadRequest();
            }

            db.Entry(thuonghieu).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!thuonghieuExists(id))
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

        // POST: api/thuonghieus
        [ResponseType(typeof(thuonghieu))]
        public IHttpActionResult Postthuonghieu(thuonghieu thuonghieu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.thuonghieus.Add(thuonghieu);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = thuonghieu.mathuonghieu }, thuonghieu);
        }

        // DELETE: api/thuonghieus/5
        [ResponseType(typeof(thuonghieu))]
        public IHttpActionResult Deletethuonghieu(int id)
        {
            thuonghieu thuonghieu = db.thuonghieus.Find(id);
            if (thuonghieu == null)
            {
                return NotFound();
            }

            db.thuonghieus.Remove(thuonghieu);
            db.SaveChanges();

            return Ok(thuonghieu);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool thuonghieuExists(int id)
        {
            return db.thuonghieus.Count(e => e.mathuonghieu == id) > 0;
        }
    }
}
