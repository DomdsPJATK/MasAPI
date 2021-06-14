using System.Threading.Tasks;
using MasAPI.DTOs.Requests;
using MasAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MasAPI.Controllers
{

    [ApiController]
    [Route("fields")]
    public class FieldsController : ControllerBase
    {

        private readonly IFieldDataBaseService _service;

        public FieldsController(IFieldDataBaseService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(FieldRequest request)
        {
            return await _service.Create(request);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await _service.Get();
        }

        [HttpGet("{idField}")]
        public async Task<IActionResult> Get(int idField)
        {
            return await _service.Get(idField);
        }

        [HttpPost("terms")]
        public async Task<IActionResult> GetTermsForDate(TermsRequest request)
        {
            return await _service.GetTermsForDate(request);
        }
        
    }
}