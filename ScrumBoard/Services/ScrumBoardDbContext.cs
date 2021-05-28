using Microsoft.EntityFrameworkCore;
using ScrumBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumBoard.Services {
    public class ScrumBoardDbContext : DbContext {
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public ScrumBoardDbContext(DbContextOptions<ScrumBoardDbContext> options) : base(options) {
            Database.Migrate();
        }
    }
}
