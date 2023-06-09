﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingApp_Core;
using ParkingApp_Core.Models;
using ParkingWebApi.Application.UserOperations.Commands.LoginUser;
using ParkingWebApi.Application.UserOperations.Queries.GetUsers;
using ParkingWebApi.Comman;
using ParkingWebApi.Data;

namespace ParkingWebApi.Controllers
{
    [Route("[controller]s/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ParkingSystemDbContext _context;
        private readonly IMapper _mapper;
        public UserController(ParkingSystemDbContext context, IMapper
            mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var response = new Response();
            GetUsersQuery query = new(_context, _mapper);
            var result = await query.Handle();
            response.Success = true;
            response.Result = result;
            return new JsonResult(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserModel login)
        {
            var response = new Response();
            try
            {
                var user = await _context.Users.Include(s => s.Score).FirstOrDefaultAsync(x => x.Email == login.Email && x.Password == login.Password);
                if (user is null)
                {
                    response.Message = "Kullanıcı bulunamadı";
                    return new JsonResult(response);
                }
                LoginUserCommand command = new(_context, _mapper);
                command.Model = login;
                command.User = user;
                var result = await command.Handle();
                response.Success = true;
                response.Result = result;
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                response.getException(ex);
            }
            return new JsonResult(response);
        }



        [HttpPost]
        public async Task<IActionResult> CreateUser(UserRequestModel.Register register)
        {
            var response = new Response();

            try
            {
                if (!ModelState.IsValid)
                    return new JsonResult(ResponseProvier.ModelState(ModelState.Values));
                var user2 = await _context.Users.FirstOrDefaultAsync(u => u.Email == register.Email);
                if (user2 is not null)
                {
                    response.AlreadyExist();
                    return new JsonResult(response);
                }
                var user = new User()
                {
                    Email = register.Email,
                    Password = register.Password,
                    FirstName = register.FirstName,
                    LastName = register.LastName,
                    Car_Plate = register.CarPlate,
                    Score = new Score()
                    {
                        Point = 0
                    },
                };
                await _context.AddAsync(user);
                await _context.SaveChangesAsync();
                response.Success = true;
                response.CreateStatus(true);
            }
            catch (Exception ex)
            {
                response.getException(ex);
            }
            return new JsonResult(response);

        }
    }
}
