using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaCursosOnline.Models;

namespace SistemaCursosOnline.Data
{
    public class SCOnlineContext : DbContext
    {
        public SCOnlineContext (DbContextOptions<SCOnlineContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new DbInitializer(modelBuilder).Seed();
        }
        public DbSet<SistemaCursosOnline.Models.Course>? Courses { get; set; }
        public DbSet<SistemaCursosOnline.Models.Schedule>? Schedule { get; set; }
        public DbSet<SistemaCursosOnline.Models.Teacher>? Teacher{ get; set; }
        public DbSet<SistemaCursosOnline.Models.TeacherScheduling>? TeacherScheduling { get; set; }
    }
}
