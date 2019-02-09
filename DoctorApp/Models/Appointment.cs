﻿using System;

namespace DoctorApp.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Comments { get; set; }

        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }

        public Patient Patient { get; set; }

        public int PatientId { get; set; }
    }
}