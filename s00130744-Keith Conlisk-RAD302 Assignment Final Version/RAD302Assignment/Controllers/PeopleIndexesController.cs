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
    public class PeopleIndexesController : ApiController
    {
        private InfomationContext db = new InfomationContext();

        // GET: api/PeopleIndexes
        public IQueryable<PeopleIndex> GetPeople()
        {
            return db.People.Include(c => c.People);
        }

        // GET: api/PeopleIndexes/5
        [ResponseType(typeof(PeopleIndex))]
        public IHttpActionResult GetPeopleIndex(int id)
        {
            PeopleIndex @peopleIndex = db.People.Find(id);
            if (@peopleIndex == null)
            {
                return NotFound();
            }

            List<PersonInfo> personInfos = db.People.Where(s => s.@peopleIndexID == @peopleIndex.ID).ToList();
            @peopleIndex.People = personInfos;

            return Ok(peopleIndex);
        }

        // PUT: api/PeopleIndexes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPeopleIndex(int id, PeopleIndex peopleIndex)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != peopleIndex.ID)
            {
                return BadRequest();
            }

            db.Entry(peopleIndex).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeopleIndexExists(id))
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

        // POST: api/PeopleIndexes
        [ResponseType(typeof(PeopleIndex))]
        public IHttpActionResult PostPeopleIndex(PeopleIndex peopleIndex)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.People.Add(peopleIndex);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = peopleIndex.ID }, peopleIndex);
        }

        // DELETE: api/PeopleIndexes/5
        [ResponseType(typeof(PeopleIndex))]
        public IHttpActionResult DeletePeopleIndex(int id)
        {
            PeopleIndex peopleIndex = db.People.Find(id);
            if (peopleIndex == null)
            {
                return NotFound();
            }

            db.People.Remove(peopleIndex);
            db.SaveChanges();

            return Ok(peopleIndex);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PeopleIndexExists(int id)
        {
            return db.People.Count(e => e.ID == id) > 0;
        }

        #region PeopleIndexs
        /*
        // GET: People
        public IHttpActionResult Index()
        {
            return View(db.People.ToList());
        }

        // GET: People/Details/5
        public IHttpActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeopleIndex peopleIndex = db.People.Find(id);
            if (peopleIndex == null)
            {
                return HttpNotFound();
            }
            return View(peopleIndex);
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
        public IHttpActionResult Create([Bind(Include = "ID,Name,Cost,Class,ImageURL")] PeopleIndex peopleIndex)
        {
            if (ModelState.IsValid)
            {
                db.PeopleIndex.Add(peopleIndex);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(peopleIndex);
        }

        // GET: People/Edit/5
        public IHttpActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeopleIndex peopleIndex = db.People.Find(id);
            if (peopleIndex == null)
            {
                return HttpNotFound();
            }
            return View(peopleIndex);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IHttpActionResult Edit([Bind(Include = "ID,Name,Age")] PeopleIndex peopleIndex)
        {
            if (ModelState.IsValid)
            {
                db.Entry(peopleIndex).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(peopleIndex);
        }

        // GET: People/Delete/5
        public IHttpActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeopleIndex peopleIndex = db.People.Find(id);
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
            PeopleIndex peopleIndex = db.People.Find(id);
            db.People.Remove(peopleIndex);
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
