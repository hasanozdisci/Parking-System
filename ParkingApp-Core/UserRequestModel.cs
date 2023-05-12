namespace ParkingApp_Core
{
    public class UserRequestModel
    {
        public class Login
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
        public class Register
        {
            public string Email { get; set; }
            public string Password { get; set; }
            public string CarPlate { get; set; }
        }
    }
}