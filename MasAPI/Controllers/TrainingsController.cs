using System.Threading.Tasks;
using MasAPI.DTOs.Requests;
using MasAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MasAPI.Controllers
{
    [ApiController]
    [Route("trainings")]
    public class TrainingsController : ControllerBase
    {
        private readonly ITrainingDataBaseService _service;

        public TrainingsController(ITrainingDataBaseService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(TrainingRequest request)
        {
            return await _service.Create(request);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await _service.Get();
        }

        [HttpGet("{idTraining}")]
        public async Task<IActionResult> Get(int idTraining)
        {
            return await _service.Get(idTraining);
        }
    }
}