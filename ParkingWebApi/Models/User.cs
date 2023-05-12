namespace ParkingWebApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Score Score { get; set; }
        public Car Car { get; set; }
    }
}
