using System;
using System.Threading.Tasks;
using MasAPI.DTOs.Requests;
using MasAPI.Models;
using MasAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MasAPI.Services
{
    public class FieldDataBaseService : IFieldDataBaseService
    {
        private readonly DataBaseContext _context;

        public async Task<IActionResult> Get()
        {
            return new OkObjectResult(await _context.Fields.ToListAsync());
        }

        public async Task<IActionResult> Get(int id)
        {
            var field = await _context.Fields.FirstOrDefaultAsync(o => o.FieldId == id);
            
            if (field == null) return new NotFoundResult();

            return new OkObjectResult(field);
        }

        public async Task<IActionResult> Create(FieldRequest request)
        {
            var address = await _context.Addresses.FirstOrDefaultAsync(o => o.AddressId == request.AddressId);

            if(address == null) return new NotFoundResult(); //Walidacja czy adres istnieje

            var field = new Field()
            {
                SeatQuantity = request.SeatQuantity,
                AddressId = request.AddressId,
                Name = request.Name
            };

            await _context.AddAsync(field);
            await _context.SaveChangesAsync();
            
            return new OkResult();
        }
    }
}