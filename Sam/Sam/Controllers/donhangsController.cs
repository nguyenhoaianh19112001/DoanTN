using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Newtonsoft.Json;
using Sam.Models;

namespace Sam.Controllers
{
    public class donhangsController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/donhangs
        public List<donhang> Getdonhangs()
        {
            var data = db.donhangs.ToList();
            return data;
        }
        [HttpGet]
        [Route("api/donhangs/chitietdonhang")]

        public IHttpActionResult Chitietdonhang()
        {
            var data = db.chitietdonhangs.ToList();
            return Ok(data);
        }

        // GET: api/donhangs/5
        [ResponseType(typeof(donhang))]
        public IHttpActionResult Getdonhang(int id)
        {
            donhang donhang = db.donhangs.Find(id);
            if (donhang == null)
            {
                return NotFound();
            }

            return Ok(donhang);
        }
       
       
        // PUT: api/donhangs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putdonhang(int id, donhang donhang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != donhang.madonhang)
            {
                return BadRequest();
            }

            db.Entry(donhang).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!donhangExists(id))
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

        // POST: api/donhangs
        [ResponseType(typeof(donhang))]
        public IHttpActionResult Postdonhang(donhangModel donhang)
        {
            donhang dh = new donhang()
            {
                diachi = donhang.diachi,
                ngaydat = DateTime.Now.ToString(),
                ghichu = donhang.ghichu,
                sodienthoai = donhang.sodienthoai,
                tongtien = donhang.tongtien,
                tenkh = donhang.tenkh,
                trangthaidon = "Chờ xác nhận",
                makh=donhang.makh,
                madonhang=donhang.madonhang

            };
            db.donhangs.Add(dh);

            try
            {
                db.SaveChanges();
                foreach (var p in donhang.chitietdonhangs)
                {
                    chitietdonhang od = new chitietdonhang()
                    {

                        masp = p.masp,
                        madonhang=dh.madonhang,
                        dongia = p.dongia,
                        soluong = p.soluong,
                        
                    };
                    db.chitietdonhangs.Add(od);

                }
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (donhangExists(donhang.madonhang))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = donhang.madonhang }, donhang);
        }
        //pos
        [HttpPut]
        [Route("api/donhangs/changestatus/{id}")]
        public IHttpActionResult ChangeDonHangStatus(int id, donhang donhang)
        {
            donhang dh = db.donhangs.Find(id);
            if (dh == null)
            {
                return NotFound();
            }
            dh.trangthaidon = donhang.trangthaidon;

            //dh.trangthaidon = "đang chờ xác nhận"; 
            

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!donhangExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(dh);
        }
        // DELETE: api/donhangs/5
        [ResponseType(typeof(donhang))]
        public IHttpActionResult Deletedonhang(int id)
        {
            donhang donhang = db.donhangs.Find(id);
            if (donhang == null)
            {
                return NotFound();
            }

            db.donhangs.Remove(donhang);
            db.SaveChanges();

            return Ok(donhang);
        }
       

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool donhangExists(int id)
        {
            return db.donhangs.Count(e => e.madonhang == id) > 0;
        }
    }
}