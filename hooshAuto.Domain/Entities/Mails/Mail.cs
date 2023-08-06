using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hooshAuto.Domain.Entities.Mails
{
    public class Mail
    {
        public long Id { get; set; }
        public string Sender { get; set; }
        public string Reciever { get; set; }
        public string Title { get; set; }
        public string content { get; set; }
      
    }
}
