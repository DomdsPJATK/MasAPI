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
        
        //Dodawanie meczu
        [HttpPost("create")]
        public async Task<IActionResult> Create(MatchRequest request)
        {
            return await _service.Create(request);
        }
        
        //Pobieranie wszystkich meczy
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await _service.Get();
        }
        
        //Pobieranie meczu po id
        [HttpGet("{idMatch}")]
        public async Task<IActionResult> Get(int idMatch)
        {
            return await _service.Get(idMatch);
        }
        
        //Dodawanie sedziego
        [HttpGet("addReferee/{idMatch}/{idReferee}")]
        public async Task<IActionResult> AddRefereeToMatch(int idMatch, int idReferee)
        {
            return await _service.AddRefereeToMatchById(idMatch, idReferee);
        }
        
        //Zmiana statusu
        [HttpPost("changeStatus")]
        public async Task<IActionResult> ChangeStatus(ChangeStatusRequest request)
        {
            return await _service.ChangeStatus(request);
        }
        

    }
}