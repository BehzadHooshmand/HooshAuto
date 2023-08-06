using hooshAuto.Application.Interfaces.Contexts;
using hooshAuto.Common;
using hooshAuto.Common.Dto;
using hooshAuto.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hooshAuto.Application.Services.Users.Commands.UserLogin
{
    public interface IUserLoginService
    {
        ResultDto<ResultUserloginDto> Execute(string Username, string Password);
    }

    public class UserLoginService : IUserLoginService
    {
        private readonly IDataBaseContext _context;
        public UserLoginService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultUserloginDto> Execute(string Username, string Password)
        {

            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                return new ResultDto<ResultUserloginDto>()
                {
                    Data = new ResultUserloginDto()
                    {

                    },
                    IsSuccess = false,
                    Message = "نام کاربری و رمز عبور را وارد نمایید",
                };
            }



            var user = _context.Users
                .Where(p => p.Email.Equals(Username))
            .FirstOrDefault();

            if (user == null)
            {
                return new ResultDto<ResultUserloginDto>()
                {
                    Data = new ResultUserloginDto()
                    {

                    },
                    IsSuccess = false,
                    Message = "کاربری با این ایمیل در سایت فروشگاه باگتو ثبت نام نکرده است",
                };
            }

            
            if (user.Password != Password)
            {
                return new ResultDto<ResultUserloginDto>()
                {
                    Data = new ResultUserloginDto()
                    {

                    },
                    IsSuccess = false,
                    Message = "رمز وارد شده اشتباه است!",
                };
            }


            var roleId = user.RoleId;
           


            return new ResultDto<ResultUserloginDto>()
            {
                Data = new ResultUserloginDto()
                {
                    RoleId = roleId,
                    UserId = user.Id,
                    Name = user.FullName
                },
                IsSuccess = true,
                Message = "ورود به سایت با موفقیت انجام شد",
            };


        }
    }

    public class ResultUserloginDto
    {
        public long UserId { get; set; }
        public long RoleId { get; set; }
        public string Name { get; set; }
    }
}
