using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingApp_Core;
using ParkingApp_Core.Models;
using ParkingWebApi.Data;

namespace ParkingWebApi.Application.UserOperations.Commands.LoginUser
{
    public class LoginUserCommand
    {
        public LoginUserModel Model { get; set; }
        private readonly ParkingSystemDbContext _context;
        private readonly IMapper _mapper;
        public User? User { get; set; }
        public Score Score { get; set; }
        public LoginUserCommand(ParkingSystemDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<LoginUserViewModel> Handle()
        {
            LoginUserViewModel viewModel = new();
            //var response = new Response();
            //var user = await _context.Users.Include(c=> c.Car).Include(s=> s.Score).FirstOrDefaultAsync(x => x.Email == Model.Email && x.Password == Model.Password);
            //if (user is null)
            //{
            //    viewModel.Message = "Kullanıcı bulunamadı";
            //}
            viewModel.Email = Model.Email;
            viewModel.Password = Model.Password;
            viewModel.CarPlate = User.Car_Plate;
            viewModel.Point = User.Score.Point;
            viewModel.Id = User.Id;
            viewModel.FirstName = User.FirstName;
            viewModel.LastName = User.LastName;
            viewModel.ParkCount = User.ParkCount;
            viewModel.FreeTicket = User.FreeTicket;
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
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Message { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CarPlate { get; set; }
        public int Point { get; set; }
        public int ParkCount { get; set; }
        public int FreeTicket { get; set; } 
    }
}
