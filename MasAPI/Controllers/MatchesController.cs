using System.Threading.Tasks;
using MasAPI.DTOs.Requests;
using MasAPI.Models;
using MasAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MasAPI.Controllers
{
    [ApiController]
    [Route("matches")]
    public class MatchesController : ControllerBase
    {
        private readonly IMatchDataBaseService _service;

        public MatchesController(IMatchDataBaseService service)
        {
            _service = service;
        }
        
        [HttpPost("create")]
        public async Task<IActionResult> Create(MatchRequest request)
        {
            return await _service.Create(request);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await _service.Get();
        }

        [HttpGet("{idMatch}")]
        public async Task<IActionResult> Get(int idMatch)
        {
            return await _service.Get(idMatch);
        }

        [HttpGet("addReferee/{idMatch}/{idReferee}")]
        public async Task<IActionResult> AddRefereeToMatch(int idMatch, int idReferee)
        {
            return await _service.AddRefereeToMatchById(idMatch, idReferee);
        }
        

    }
}