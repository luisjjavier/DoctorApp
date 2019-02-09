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
    public class AppointmentResultsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AppointmentResults
        public async Task<ActionResult> Index()
        {
            var appointmentResults = db.AppointmentResults.Include(a => a.Appointment);
            return View(await appointmentResults.ToListAsync());
        }

        // GET: AppointmentResults/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointmentResult appointmentResult = await db.AppointmentResults.FindAsync(id);
            if (appointmentResult == null)
            {
                return HttpNotFound();
            }
            return View(appointmentResult);
        }

        // GET: AppointmentResults/Create
        public ActionResult Create()
        {
            ViewBag.AppointmentId = new SelectList(db.Appointments, "Id", "Comments");
            return View();
        }

        // POST: AppointmentResults/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Recommendations,AppointmentId,Sintomas,Date")] AppointmentResult appointmentResult)
        {
            if (ModelState.IsValid)
            {
                db.AppointmentResults.Add(appointmentResult);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AppointmentId = new SelectList(db.Appointments, "Id", "Comments", appointmentResult.AppointmentId);
            return View(appointmentResult);
        }

        // GET: AppointmentResults/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointmentResult appointmentResult = await db.AppointmentResults.FindAsync(id);
            if (appointmentResult == null)
            {
                return HttpNotFound();
            }
            ViewBag.AppointmentId = new SelectList(db.Appointments, "Id", "Comments", appointmentResult.AppointmentId);
            return View(appointmentResult);
        }

        // POST: AppointmentResults/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Recommendations,AppointmentId,Sintomas,Date")] AppointmentResult appointmentResult)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointmentResult).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AppointmentId = new SelectList(db.Appointments, "Id", "Comments", appointmentResult.AppointmentId);
            return View(appointmentResult);
        }

        // GET: AppointmentResults/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointmentResult appointmentResult = await db.AppointmentResults.FindAsync(id);
            if (appointmentResult == null)
            {
                return HttpNotFound();
            }
            return View(appointmentResult);
        }

        // POST: AppointmentResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AppointmentResult appointmentResult = await db.AppointmentResults.FindAsync(id);
            db.AppointmentResults.Remove(appointmentResult);
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
