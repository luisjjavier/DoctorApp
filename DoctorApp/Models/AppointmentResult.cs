using System;

namespace DoctorApp.Models
{
    public class AppointmentResult
    {
        public int Id { get; set; }

        public string Recommendations { get; set; }

        public Appointment Appointment { get; set; }

        public int AppointmentId { get; set; }

        public string Sintomas { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
    }
}