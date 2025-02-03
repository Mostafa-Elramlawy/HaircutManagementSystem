namespace HaircutManagementSystem.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        // Navigation property
        public ICollection<Appointment> Appointments { get; set; }
    }
}
