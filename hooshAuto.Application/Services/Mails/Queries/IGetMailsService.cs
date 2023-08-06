using hooshAuto.Application.Interfaces.Contexts;
using hooshAuto.Application.Services.Users.Queries.GetUsers;
using hooshAuto.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hooshAuto.Application.Services.Mails.Queries
{
    public interface IGetMailsService
    {
        ReslutGetMailsDto Execute(string? userEmail);

    }

    public class GetMailsService : IGetMailsService
    {

        private readonly IDataBaseContext _context;
        public GetMailsService(IDataBaseContext context)
        {
            _context = context;
        }
        public ReslutGetMailsDto Execute(string? userEmail)
        {
            var mails = _context.Mails.AsQueryable();
            mails = mails.Where(p => p.Reciever.Contains(userEmail));

            var mailsList = mails.Select(p => new GetMailsDto
            {
                Sender = p.Sender,
                Reciever=p.Reciever,
                Title = p.Title,
                Id = p.Id,
            }).ToList();

            return new ReslutGetMailsDto
            {
                Mails = mailsList,
            };
        }
    }
    public class GetMailsDto
    {
        public long Id { get; set; }
        public string Sender { get; set; }
        public string Reciever { get; set; }
        public string Title { get; set; }
       

    }

   
    public class ReslutGetMailsDto
    {
        public List<GetMailsDto> Mails { get; set; }

    }
}
