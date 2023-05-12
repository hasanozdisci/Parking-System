namespace ParkingWebApi.Models
{
    public class Score
    {
        public int Id { get; set; }
        public string Point { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
