using ParkingApp_Core.Models;

namespace ParkingWebApi.Application.UserOperations.Queries.GetParks
{
    public class GetParksViewModel
    {
        public bool IsBusy { get; set; } = false;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? CarPlate { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
