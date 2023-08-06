using hooshAuto.Application.Interfaces.Contexts;
using hooshAuto.Application.Services.Users.Commands.RegisterUser;
using hooshAuto.Common.Dto;
using hooshAuto.Domain.Entities.Mails;
using hooshAuto.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hooshAuto.Application.Services.Mails.Commands.CreateMail
{
    public interface ICreateMailService
    {
        public ResultDto Execute(RequestCreateMailDto request);
    }

    public class CreateMailService : ICreateMailService
    {
        private readonly IDataBaseContext _context;

        public CreateMailService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestCreateMailDto request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.Sender))
                {
                    return new ResultDto()
                    {
                       
                        IsSuccess = false,
                        Message = "ایمیل گیرنده را وارد نمایید"
                    };
                }

                if (string.IsNullOrWhiteSpace(request.Reciever))
                {
                    return new ResultDto()
                    {
                        
                        IsSuccess = false,
                        Message = "ایمیل فرستنده را وارد کنید"
                    };
                }
                

                Mail mail = new Mail()
                {
                    Sender = request.Sender,
                    Reciever = request.Reciever,
                    Title = request.Title,
                    content = request.content,
                };

                _context.Mails.Add(mail);

                _context.SaveChanges();

                return new ResultDto()
                {
                   
                    IsSuccess = true,
                    Message = "پیام ارسال شد",
                };
            }
            catch (Exception)
            {
                return new ResultDto()
                {
                    
                    IsSuccess = false,
                    Message = "ارسال پیام با خطا مواجه شد"
                };
            }
        }
    }
    public class RequestCreateMailDto
    {
        public string Sender { get; set; }
        public string Reciever { get; set; }
        public string Title { get; set; }
        public string content { get; set; }

    }

    
}
