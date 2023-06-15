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
    public class dungtichsController : ApiController
    {
        private Model1 db = new Model1();

        // GET: dungtichs
        public IQueryable<dungtich> Getdungtichs()
        {
            return db.dungtichs;
        }


        // GET: dungtichs/Details/5

        [ResponseType(typeof(dungtich))]
        public IHttpActionResult Getdungtich(int? id)
        {
            dungtich dungtich = db.dungtichs.Find(id);
            if (dungtich is null)
            {
                return NotFound();
            }

            return Ok(dungtich);
        }


        // PUT: api/dungtichs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putdungtich(int id, dungtich dungtich)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dungtich.madungtich)
            {
                return BadRequest();
            }

            db.Entry(dungtich).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!dungtichExists(id))
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

        // POST: api/dungtichs
        [ResponseType(typeof(dungtich))]
        public IHttpActionResult Postdungtich(dungtich dungtich)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.dungtichs.Add(dungtich);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dungtich.madungtich }, dungtich);
        }

        // DELETE: api/dungtichs/5
        [ResponseType(typeof(dungtich))]
        public IHttpActionResult Deletedungtich(int id)
        {
            dungtich dungtich = db.dungtichs.Find(id);
            if (dungtich == null)
            {
                return NotFound();
            }

            db.dungtichs.Remove(dungtich);
            db.SaveChanges();

            return Ok(dungtich);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool dungtichExists(int id)
        {
            return db.dungtichs.Count(e => e.madungtich == id) > 0;
        }
    }
}
