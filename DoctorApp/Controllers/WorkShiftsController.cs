using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoctorApp.Models;

namespace DoctorApp.Controllers
{
    public class WorkShiftsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WorkShifts
        public async Task<ActionResult> Index()
        {
            return View(await db.WorkShifts.ToListAsync());
        }

        // GET: WorkShifts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkShift workShift = await db.WorkShifts.FindAsync(id);
            if (workShift == null)
            {
                return HttpNotFound();
            }
            return View(workShift);
        }

        // GET: WorkShifts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkShifts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Description")] WorkShift workShift)
        {
            if (ModelState.IsValid)
            {
                db.WorkShifts.Add(workShift);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(workShift);
        }

        // GET: WorkShifts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkShift workShift = await db.WorkShifts.FindAsync(id);
            if (workShift == null)
            {
                return HttpNotFound();
            }
            return View(workShift);
        }

        // POST: WorkShifts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Description")] WorkShift workShift)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workShift).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(workShift);
        }

        // GET: WorkShifts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkShift workShift = await db.WorkShifts.FindAsync(id);
            if (workShift == null)
            {
                return HttpNotFound();
            }
            return View(workShift);
        }

        // POST: WorkShifts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            WorkShift workShift = await db.WorkShifts.FindAsync(id);
            db.WorkShifts.Remove(workShift);
            await db.SaveChangesAsync();
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
    }
}
