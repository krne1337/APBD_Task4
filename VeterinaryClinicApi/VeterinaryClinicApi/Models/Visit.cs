namespace VeterinaryClinicApi.Models
{
    public class Visit
    {
        public int Id { get; set; }
        public DateTime DateOfVisit { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
