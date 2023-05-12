namespace ParkingWebApi.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Car_Plate { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
