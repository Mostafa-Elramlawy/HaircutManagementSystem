namespace HaircutManagementSystem.Models
{
    public class Barber
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }

        // Navigation property
        public ICollection<Appointment> Appointments { get; set; }
    }
}
