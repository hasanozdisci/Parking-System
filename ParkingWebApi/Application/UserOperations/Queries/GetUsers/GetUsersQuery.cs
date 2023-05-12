using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ParkingWebApi.Data;

namespace ParkingWebApi.Application.UserOperations.Queries.GetUsers
{
    public class GetUsersQuery
    {
        private readonly ParkingSystemDbContext _context;
        private readonly IMapper _mapper;
        public GetUsersQuery(ParkingSystemDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<UserViewModel>> Handle()
        {
            var users = await _context.Users.Include(s => s.Score).Include(c => c.Car).ToListAsync();
            List<UserViewModel> userViewModel = _mapper.Map<List<UserViewModel>>(users);
            return userViewModel;
        }
    }
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string CarPlate { get; set; }
        public string Point { get; set; }
    }
}
