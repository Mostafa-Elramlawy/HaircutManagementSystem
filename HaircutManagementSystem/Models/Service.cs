namespace HaircutManagementSystem.Models
{
    public class Service
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        // Navigation property (if needed, could be added to Appointment if there's a relationship)
        public ICollection<Appointment> Appointments { get; set; }
    }
}
