using System.Threading.Tasks;
using MasAPI.DTOs.Requests;
using Microsoft.AspNetCore.Mvc;

namespace MasAPI.Services.Interfaces
{
    public interface IFieldDataBaseService
    {
        public Task<IActionResult> Get();
        public Task<IActionResult> Get(int id);
        public Task<IActionResult> Create(FieldRequest request);
    }
}