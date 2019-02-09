namespace DoctorApp.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Identification { get; set; }
        public string Specialty { get; set; }
        public int WorkShiftId { get; set; }
        public WorkShift Workshift { get; set; }
        public Status Status { get; set; }
    }
}