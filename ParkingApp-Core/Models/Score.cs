namespace ParkingApp_Core.Models
{
    public class Score
    {
        public int Id { get; set; }
        public int Point { get; set; } = 0;
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
