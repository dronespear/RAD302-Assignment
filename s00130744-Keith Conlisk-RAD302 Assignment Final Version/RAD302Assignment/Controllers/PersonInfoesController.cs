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
using RAD302Assignment.Models;
using System.Web.Mvc;

namespace RAD302Assignment.Controllers
{
    public class PersonInfoesController : ApiController
    {
        private InfomationContext db = new InfomationContext();

        // GET: api/PersonInfoes
        public IQueryable<PersonInfo> GetPersonInfo()
        {
            return db.PersonInfo.Include(c => c.BasicInformation);
        }

        // GET: api/PersonInfoes/5
        [ResponseType(typeof(PersonInfo))]
        public IHttpActionResult GetPersonInfo(int id)
        {
            PersonInfo @personInfo = db.PersonInfo.Find(id);
            if (@personInfo == null)
            {
                return NotFound();
            }
            
            List<PeopleIndex> peopleindex = db.PersonInfo.Where(s => s.@PersonInfoID == @personInfo.ID).ToList();
            @personInfo.BasicInformation = peopleindex;

            return Ok(personInfo);
        }

        // PUT: api/PersonInfoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersonInfo(int id, PersonInfo personInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personInfo.ID)
            {
                return BadRequest();
            }

            db.Entry(personInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonInfoExists(id))
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

        // POST: api/PersonInfoes
        [ResponseType(typeof(PersonInfo))]
        public IHttpActionResult PostPersonInfo(PersonInfo personInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PersonInfo.Add(personInfo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = personInfo.ID }, personInfo);
        }

        // DELETE: api/PersonInfoes/5
        [ResponseType(typeof(PersonInfo))]
        public IHttpActionResult DeletePersonInfo(int id)
        {
            PersonInfo personInfo = db.PersonInfo.Find(id);
            if (personInfo == null)
            {
                return NotFound();
            }

            db.PersonInfo.Remove(personInfo);
            db.SaveChanges();

            return Ok(personInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonInfoExists(int id)
        {
            return db.PersonInfo.Count(e => e.ID == id) > 0;
        }

        #region PersonInfos
        /*
        // GET: People
        public IHttpActionResult Index()
        {
            return View(db.PersonInfo.ToList());
        }

        // GET: People/Details/5
        public IHttpActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonInfo personInfo = db.PersonInfo.Find(id);
            if (personInfo == null)
            {
                return HttpNotFound();
            }
            return View(personInfo);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IHttpActionResult Create([Bind(Include = "ID,FirstName,LastName,Gender,Age,Nationality,Job")] PersonInfo personInfo)
        {
            if (ModelState.IsValid)
            {
                db.PersonInfo.Add(personInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personInfo);
        }

        // GET: People/Edit/5
        public IHttpActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonInfo personInfo = db.PersonInfo.Find(id);
            if (personInfo == null)
            {
                return HttpNotFound();
            }
            return View(personInfo);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IHttpActionResult Edit([Bind(Include = "ID,Name,Age")] PersonInfo personInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personInfo);
        }

        // GET: People/Delete/5
        public IHttpActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonInfo peopleIndex = db.PersonInfo.Find(id);
            if (peopleIndex == null)
            {
                return HttpNotFound();
            }
            return View(peopleIndex);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IHttpActionResult DeleteConfirmed(int id)
        {
            PersonInfo peopleIndex = db.PersonInfo.Find(id);
            db.PersonInfo.Remove(personInfo);
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
        */
        #endregion
    }
}