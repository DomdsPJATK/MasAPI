using System;
using System.Threading.Tasks;
using MasAPI.DTOs.Requests;
using MasAPI.Models;
using MasAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MasAPI.Services
{
    public class TeamDataBaseService : ITeamDataBaseService
    {
        private readonly DataBaseContext _context;

        public async Task<IActionResult> Get()
        {
            return new OkObjectResult(await _context.Teams.ToListAsync());
        }

        public async Task<IActionResult> Get(int id)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(o => o.TeamId == id);
            
            if (team == null) return new NotFoundResult();

            return new OkObjectResult(team);
        }

        public async Task<IActionResult> Create(TeamRequest request)
        {
            if (!Enum.IsDefined(typeof(Leagues), request.League)) return new BadRequestResult(); //Walidacja czy wartosc w enumie o nazwie {value} istnieje.

            Leagues league = (Leagues) Enum.Parse(typeof(Leagues), request.League);
            
            var team = new Team()
            {
                Name = request.Name,
                League = league,
                Year = request.Year
                
            };

            await _context.AddAsync(team);
            await _context.SaveChangesAsync();
            
            return new OkResult();
        }

        //Nie jest częścią glownego PU
       public async Task<IActionResult> AddPlayerToTeam(int playerId, int teamId)
        {
            return new OkResult();
        }
    }
}