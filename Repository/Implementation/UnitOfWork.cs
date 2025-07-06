using Multi_Stage_ATS.Data;
using Multi_Stage_ATS.Models;
using Multi_Stage_ATS.Repository.Interface;

namespace Multi_Stage_ATS.Repository.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IRepository<Applicant> Applicants { get; }
        public IRepository<Stage> Stages { get; }
        public IRepository<Application> Applications { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Applicants = new Repository<Applicant>(context);
            Stages = new Repository<Stage>(context);
            Applications = new Repository<Application>(context);
        }

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();
    }
}
