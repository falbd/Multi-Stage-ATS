using Microsoft.AspNetCore.Mvc;
using Multi_Stage_ATS.DTO;
using Multi_Stage_ATS.Models;
using Multi_Stage_ATS.Repository.Interface;

namespace Multi_Stage_ATS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicantsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ApplicantsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get() =>
            Ok(await _unitOfWork.Applicants.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var applicant = await _unitOfWork.Applicants.GetByIdAsync(id);
            return applicant == null ? NotFound() : Ok(applicant);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateApplicantDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var applicant = new Applicant
            {
                FullName = dto.FullName,
                Email = dto.Email
            };

            await _unitOfWork.Applicants.AddAsync(applicant);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(Get), new { id = applicant.Id }, applicant);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var applicant = await _unitOfWork.Applicants.GetByIdAsync(id);
            if (applicant == null) return NotFound();
            _unitOfWork.Applicants.Remove(applicant);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }
    }
}