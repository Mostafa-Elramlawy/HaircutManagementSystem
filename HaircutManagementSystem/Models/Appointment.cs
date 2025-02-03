namespace HaircutManagementSystem.Models
{
    public class Appointment
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public int BarberId { get; set; }
        public int ServiceId { get; set; }
        public string Notes { get; set; }

        // Navigation properties
        public Customer Customer { get; set; }
        public Barber Barber { get; set; }
        public Service Service { get; set; }
    }
}
