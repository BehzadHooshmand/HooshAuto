using hooshAuto.Application.Interfaces.Contexts;
using hooshAuto.Domain.Entities.Mails;
using hooshAuto.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hooshAuto.Persistence.Contexts
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }

        public DbSet<Mail> Mails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //افزودن مقادیر پیشفرض به جدول Roles
            //modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Name = nameof(UserRoles.Admin) });
            //modelBuilder.Entity<Role>().HasData(new Role { Id = 2, Name = nameof(UserRoles.Operator) });


            // اعمال ایندکس بر روی فیلد ایمیل
            // اعمال عدم تکراری بودن ایمیل
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();


          

            //modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsRemoved);
        }
    }
   
}
