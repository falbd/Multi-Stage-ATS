using Multi_Stage_ATS.Models;

namespace Multi_Stage_ATS.Repository.Interface
{
    public interface IUnitOfWork
    {
        IRepository<Applicant> Applicants { get; }
        IRepository<Stage> Stages { get; }
        IRepository<Application> Applications { get; }
        Task<int> CompleteAsync();
    }
}
