using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingApp_Core;
using ParkingWebApi.Application.UserOperations.Queries.GetParks;
using ParkingWebApi.Comman;
using ParkingWebApi.Data;

namespace ParkingWebApi.Controllers
{
    [Route("[controller]s/[action]")]
    [ApiController]
    public class ParkController : ControllerBase
    {
        public ParkingSystemDbContext _context;
        public ParkController(ParkingSystemDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetParks()
        {
            List<GetParksViewModel> vm = new();
            var response = new ParkingApp_Core.Response();
            var parks = await _context.Parks.Include(u => u.User).ToListAsync();
            // if park isbuys equals true, then get the user who bought the park
            foreach (var park in parks)
            {
                if (park.IsBusy)
                {
                    vm.Add(new GetParksViewModel
                    {
                        IsBusy = park.IsBusy,
                        FirstName = park.User.FirstName,
                        LastName = park.User.LastName,
                        CarPlate = park.User.Car_Plate,
                        UserId = park.User.Id
                    });
                }
                else
                {
                    vm.Add(new GetParksViewModel
                    {
                        IsBusy = park.IsBusy
                    });
                }
            }
            response.Success = true;
            response.Result = vm;
            return new JsonResult(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetParkById(UserRequestModel.GetById parks)
        {
            var response = new ParkingApp_Core.Response();
            var park = await _context.Parks.Include(u => u.User).FirstOrDefaultAsync(p => p.Id == parks.Id);
            if (park == null)
            {
                response.Success = false;
                response.Message = "Park not found";
                return new JsonResult(response);
            }
            response.Success = true;
            GetParksViewModel vm = new();
            if (park.IsBusy)
            {
                vm.IsBusy = park.IsBusy;
                vm.FirstName = park.User.FirstName;
                vm.LastName = park.User.LastName;
                vm.CarPlate = park.User.Car_Plate;
                vm.UserId = park.User.Id;
            }
            vm.IsBusy = park.IsBusy;

            response.Result = vm;
            return new JsonResult(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePark(UserRequestModel.GetByIdWithUser park)
        {
            var response = new ParkingApp_Core.Response();
            var parkById = await _context.Parks.FirstOrDefaultAsync(p => p.Id == park.Id);
            if (parkById is null)
            {
                response.Success = false;
                response.Message = "Park not found";
                return new JsonResult(response);
            }
            parkById.IsBusy = parkById.IsBusy == true ? false : true;
            if(!parkById.IsBusy)
            {
                parkById.UserId = null;
            }
            else
            {
                parkById.UserId = park.UserId;
            }
            await _context.SaveChangesAsync();
            response.Success = true;
            response.Result = parkById;
            return new JsonResult(response);
        }
    }
}
