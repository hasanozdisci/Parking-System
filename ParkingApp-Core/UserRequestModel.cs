using System.ComponentModel.DataAnnotations;

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

            [DataType(DataType.EmailAddress)]
            [EmailAddress(ErrorMessage = "E-posta adresi geçersiz")]
            public string Email { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Password { get; set; }
            public string CarPlate { get; set; }
        }
        public class UpdateScore
        {
            public int Id { get; set; }
            public int Point { get; set; }
        }
        public class GetById
        {
            public int Id { get; set; }
        }
        public class GetByIdWithUser
        {
            public int Id { get; set; }
            public int UserId { get; set; }
        }
    }
}