namespace ParkingApp_Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Car_Plate { get; set; }
        public int ParkCount { get; set; } = 0;
        public Park Park { get; set; }
        public Score Score { get; set; }
        public int FreeTicket { get; set; } = 0;
    }
}
