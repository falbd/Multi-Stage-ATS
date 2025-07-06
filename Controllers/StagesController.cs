using Microsoft.AspNetCore.Mvc;
using Multi_Stage_ATS.Repository.Interface;
using Multi_Stage_ATS.Models;

namespace Multi_Stage_ATS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StagesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public StagesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get() =>
            Ok(await _unitOfWork.Stages.GetAllAsync());
    }
}
