using System.Threading.Tasks;
using MasAPI.DTOs.Requests;
using MasAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MasAPI.Controllers
{
    [ApiController]
    [Route("teams")]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamDataBaseService _service;

        public TeamsController(ITeamDataBaseService service)
        {
            _service = service;
        }
        
        [HttpPost("create")]
        public async Task<IActionResult> Create(TeamRequest request)
        {
            return await _service.Create(request);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await _service.Get();
        }

        [HttpGet("{idTeam}")]
        public async Task<IActionResult> Get(int idTeam)
        {
            return await _service.Get(idTeam);
        }
    }
}