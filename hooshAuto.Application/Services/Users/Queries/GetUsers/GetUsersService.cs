using hooshAuto.Application.Interfaces.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using hooshAuto.Common;



namespace hooshAuto.Application.Services.Users.Queries.GetUsers
{
    public class GetUsersService : IGetUsersService
    {
        private readonly IDataBaseContext _context;
        public GetUsersService(IDataBaseContext context)
        {
            _context = context;
        }


        public ReslutGetUserDto Execute()
        {
            var users = _context.Users.AsQueryable();
            
            
            var usersList= users.Select(p => new GetUsersDto
            {
                Email = p.Email,
                FullName = p.FullName,
                Id = p.Id,
                RoleId = p.RoleId,
            }).ToList();

            return new ReslutGetUserDto
            {
                Users = usersList,
            };
        }
    }
}
