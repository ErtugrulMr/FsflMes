using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class FsflMesContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=MSI\SQLEXPRESS01;Database=FsflMes;Trusted_Connection=true");
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<SysAdmin> SysAdmins { get; set; }
        public DbSet<SchAdmin> SchAdmins { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostType> PostTypes { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<SchoolClass> SchoolClasses { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
