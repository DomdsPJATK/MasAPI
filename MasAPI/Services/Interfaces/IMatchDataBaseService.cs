using System.Threading.Tasks;
using MasAPI.DTOs.Requests;
using MasAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MasAPI.Services.Interfaces
{
    public interface IMatchDataBaseService
    {
        public Task<IActionResult> Get();
        public Task<IActionResult> Get(int id);
        public Task<IActionResult> Create(MatchRequest request);
        public Task<IActionResult> AddRefereeToMatchById(int idMatch, int idReferee);
    }
}