using System.Threading.Tasks;
using MasAPI.DTOs.Requests;
using MasAPI.Models;
using MasAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MasAPI.Services
{
    public class TrainingDataBaseService : ITrainingDataBaseService
    {
        private readonly DataBaseContext _context;

        public async Task<IActionResult> Get()
        {
            return new OkObjectResult(await _context.Trainings.ToListAsync());
        }

        public async Task<IActionResult> Get(int id)
        {
            var training = await _context.Trainings.FirstOrDefaultAsync(o => o.TrainingId == id);
            
            if (training == null) return new NotFoundResult();

            return new OkObjectResult(training);
        }

        public async Task<IActionResult> Create(TrainingRequest request)
        {
            
            var team = await _context.Teams.FirstOrDefaultAsync(o => o.TeamId == request.TeamId);
            var field = await _context.Fields.FirstOrDefaultAsync(o => o.FieldId == request.FieldId);
            
            if(team == null || field == null) return new NotFoundResult(); //Walidacja czy team i boisko istnieją
            
            var training = new Training()
            {
                TeamId = request.TeamId,
                FieldId = request.FieldId,
                DateSince = request.DateSince,
                DateUntil = request.DateUntil
            };

            await _context.AddAsync(training);
            await _context.SaveChangesAsync();
            
            return new OkResult();
        }
        
        //AddAccessories nie jest czescia wymaganego PU
        public async Task<IActionResult> AddAccessories(AccessoriesRequest request, int trainingId){
            
            return new OkResult();
            
        }
    }
}