using Microsoft.AspNetCore.Mvc;
using Multi_Stage_ATS.Data;
using Multi_Stage_ATS.Repository.Interface;
using Multi_Stage_ATS.Models;
using Microsoft.EntityFrameworkCore;
using Multi_Stage_ATS.DTO;

namespace Multi_Stage_ATS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public ApplicationsController(IUnitOfWork unitOfWork, ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var apps = await _context.Applications
                .Include(a => a.Applicant)
                .Include(a => a.Stage)
                .Select(a => new ApplicationDto
                {
                    Id = a.Id,
                    ApplicantId = a.ApplicantId,
                    ApplicantName = a.Applicant.FullName,
                    ApplicantEmail = a.Applicant.Email,
                    StageId = a.StageId,
                    StageName = a.Stage.Name,
                    AppliedOn = a.AppliedOn,
                    Notes = a.Notes
                })
                .ToListAsync();

            return Ok(apps);
        }




        [HttpPost]
        public async Task<IActionResult> Post(CreateApplicationDto dto)
        {
            var applicant = await _unitOfWork.Applicants.GetByIdAsync(dto.ApplicantId);
            if (applicant == null) return BadRequest("Invalid ApplicantId.");

            var stage = await _unitOfWork.Stages.GetByIdAsync(dto.StageId);
            if (stage == null) return BadRequest("Invalid StageId.");

            var application = new Application
            {
                ApplicantId = dto.ApplicantId,
                StageId = dto.StageId,
                Notes = dto.Notes,
                AppliedOn = DateTime.UtcNow
            };

            await _unitOfWork.Applications.AddAsync(application);
            await _unitOfWork.CompleteAsync();

            return Ok(application);
        }


        [HttpPut("{id}/move-stage")]
        public async Task<IActionResult> MoveStage(int id, MoveApplicationStageDto dto)
        {
            var application = await _context.Applications
                .Include(a => a.Applicant)
                .Include(a => a.Stage)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (application == null)
                return NotFound($"Application with Id {id} not found.");

            var stage = await _context.Stages.FindAsync(dto.NewStageId);
            if (stage == null)
                return BadRequest($"Stage with Id {dto.NewStageId} not found.");

            application.StageId = dto.NewStageId;
            await _context.SaveChangesAsync();

            // Return a clean DTO
            var appDto = new ApplicationDto
            {
                Id = application.Id,
                ApplicantId = application.ApplicantId,
                ApplicantName = application.Applicant.FullName,
                StageId = application.StageId,
                StageName = stage.Name,
                AppliedOn = application.AppliedOn,
                Notes = application.Notes
            };

            return Ok(appDto);
        }


    }
}