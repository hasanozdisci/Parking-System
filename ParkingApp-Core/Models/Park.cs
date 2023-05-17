namespace ParkingApp_Core.Models
{
    public class Park
    {
        public int Id { get; set; }
        public bool IsBusy { get; set; } = false;
        public User User { get; set; }
        public int? UserId { get; set; }
    }
}
