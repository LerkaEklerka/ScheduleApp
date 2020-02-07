using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ScheduleApp.Models;

namespace ScheduleApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<User> CustomUsers { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<GroupSubject> GroupSubjects { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupSubject>()
                .HasKey(gs => new { gs.GroupId, gs.SubjectId });
            base.OnModelCreating(modelBuilder);
            
        }
    }
}
