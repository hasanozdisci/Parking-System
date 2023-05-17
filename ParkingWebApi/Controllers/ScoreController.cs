using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingApp_Core;
using ParkingWebApi.Data;
using System.Runtime.CompilerServices;

namespace ParkingWebApi.Controllers
{
    [Route("[controller]s/[action]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        public ParkingSystemDbContext _context;
        public ScoreController(ParkingSystemDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetUserPoint(UserRequestModel.GetById userId)
        {
            var response = new Response();
            var user = await _context.Users.Include(s => s.Score).FirstOrDefaultAsync(u => u.Id == userId.Id);
            if (user is null)
            {
                response.Success = false;
                return new JsonResult(response);
            }
            response.Success = true;
            response.Result = user.Score.Point;
            return new JsonResult(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateScore(UserRequestModel.UpdateScore score)
        {
            var response = new Response();
            var user = await _context.Users.Include(s => s.Score).FirstOrDefaultAsync(u => u.Id == score.Id);
            if (user is null)
            {
                response.Success = false;
                return new JsonResult(response);
            }
            user.Score.Point += score.Point;
            await _context.SaveChangesAsync();
            response.Success = true;
            return new JsonResult(response);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateScoreForParking(int id)
        {
            var response = new Response();
            var user = await _context.Users.Include(s => s.Score).FirstOrDefaultAsync(u => u.Id == id);
            if (user is null)
            {
                response.Success = false;
                return new JsonResult(response);
            }
            user.Score.Point -= 5;
            user.ParkCount += 1;
            if(user.ParkCount == 10)
            {
                user.ParkCount = 0;
                user.FreeTicket += 1;
            }
            await _context.SaveChangesAsync();
            response.Success = true;
            return new JsonResult(response);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateScoreForParkingWithFreeTicket(int id)
        {
            var response = new Response();
            var user = await _context.Users.Include(s => s.Score).FirstOrDefaultAsync(u => u.Id == id);
            if (user is null)
            {
                response.Success = false;
                return new JsonResult(response);
            }
            user.FreeTicket -= 1;
            await _context.SaveChangesAsync();
            response.Success = true;
            return new JsonResult(response);
        }
    }
    
}
