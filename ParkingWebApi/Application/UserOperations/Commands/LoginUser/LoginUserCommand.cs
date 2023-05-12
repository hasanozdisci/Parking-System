using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingApp_Core;
using ParkingWebApi.Data;

namespace ParkingWebApi.Application.UserOperations.Commands.LoginUser
{
    public class LoginUserCommand
    {
        public LoginUserModel Model { get; set; }
        private readonly ParkingSystemDbContext _context;
        private readonly IMapper _mapper;
        public LoginUserCommand(ParkingSystemDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<LoginUserViewModel> Handle()
        {
            var response = new Response();
            var user = await _context.Users.Include(c=> c.Car).Include(s=> s.Score).FirstOrDefaultAsync(x => x.Email == Model.Email && x.Password == Model.Password);
            if (user is null)
            {
                throw new InvalidCastException(); 
            }
            LoginUserViewModel viewModel = new();
            viewModel.Email = Model.Email;
            viewModel.Password = Model.Password;
            viewModel.CarPlate = user.Car.Car_Plate;
            viewModel.Point = user.Score.Point;
            return viewModel;
        }
    }

    public class LoginUserModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class LoginUserViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string CarPlate { get; set; }
        public string Point { get; set; }
    }
}
