using System.Collections.Generic;

namespace DoctorApp.Models
{
    public class Patient
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }

        public int Age { get; set; }

        public string Identification { get; set; }
        public string NoCarnet { get; set; }
        public Status Status { get; set; }
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        
    }

    public enum Status
    {
        Active = 1,
        Inactive = 2
    }
}