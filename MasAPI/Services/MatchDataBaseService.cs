using System;
using System.Linq;
using System.Threading.Tasks;
using MasAPI.DTOs.Requests;
using MasAPI.Models;
using MasAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MasAPI.Services
{
    public class MatchDataBaseService : IMatchDataBaseService
    {
        private readonly DataBaseContext _context;

        public async Task<IActionResult> Get()
        {
            return new OkObjectResult(await _context.Matches.ToListAsync());
        }

        public async Task<IActionResult> Get(int id)
        {
            var match = await _context.Matches.FirstOrDefaultAsync(o => o.MatchId == id);
            
            if (match == null) return new NotFoundResult(); //Walidacja czy mecz istnieje

            return new OkObjectResult(match);
        }

        public async Task<IActionResult> Create(MatchRequest request)
        {
            if (!Enum.IsDefined(typeof(CreationStages), request.Status)) return new BadRequestResult(); //Walidacja czy wartosc w enumie o nazwie {value} istnieje.

            CreationStages creationStages = (CreationStages) Enum.Parse(typeof(CreationStages), request.Status);
            
            var team = await _context.Teams.FirstOrDefaultAsync(o => o.TeamId == request.TeamId);
            var field = await _context.Fields.FirstOrDefaultAsync(o => o.FieldId == request.FieldId);
            
            if(team == null || field == null) return new NotFoundResult(); //Walidacja czy team i boisko istnieją
            
            var match = new Match()
            {
                TeamId = request.TeamId,
                FieldId = request.TeamId,
                EnemyName = request.EnemyName,
                DateSince = request.DateSince,
                DateUntil = request.DateUntil,
                Status = creationStages
            };

            await _context.AddAsync(match);
            await _context.SaveChangesAsync();
            
            return new OkResult();
        }

        public async Task<IActionResult> AddRefereeToMatchById(int idMatch, int idReferee)
        {
            var referee = await _context.Referees.FirstOrDefaultAsync(o => o.PersonId == idReferee);
            var match = await _context.Matches.FirstOrDefaultAsync(o => o.MatchId == idMatch);
            
            if(referee == null || match == null) return new NotFoundResult(); //Walidacja czy sedzia lub mecz istnieje

            match.Referee = referee;

            await _context.SaveChangesAsync();

            return new OkResult();

        }
    }
}