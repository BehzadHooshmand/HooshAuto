using hooshAuto.Domain.Entities.Users;
using hooshAuto.Domain.Entities.Mails;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace hooshAuto.Application.Interfaces.Contexts
{
    public interface IDataBaseContext
    {
        DbSet<User> Users { get; set; }

        DbSet<Mail> Mails { get; set; }

        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());


    }
}
