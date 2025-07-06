using Microsoft.EntityFrameworkCore;
using Multi_Stage_ATS.Models;
using System.Collections.Generic;

namespace Multi_Stage_ATS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Applicant> Applicants => Set<Applicant>();
        public DbSet<Stage> Stages => Set<Stage>();
        public DbSet<Application> Applications => Set<Application>();
    }
}
