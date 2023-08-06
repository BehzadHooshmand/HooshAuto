using hooshAuto.Application.Interfaces.Contexts;
using hooshAuto.Common.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hooshAuto.Application.Services.Mails.Queries.ShowMailContent
{
    public interface IShowMailContent
    {
        ResultDto<MailContentDto> Execute(long Id);
    }
    

    public class ShowMailContent : IShowMailContent
    {
        private readonly IDataBaseContext _context;
        public ShowMailContent(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<MailContentDto> Execute(long Id)
        {
            var mail = _context.Mails
                .Where(p => p.Id == Id).FirstOrDefault();

            if (mail == null)
            {
                throw new Exception("Mail Not Found.....");
            }

            return new ResultDto<MailContentDto>()
            {
                Data = new MailContentDto
                {
                    MailContent =mail.content
                    
                },
                IsSuccess = true,
            };

        }
    }

    public class MailContentDto
    {
        
        public string MailContent { get; set; }
      
    }

    

}
