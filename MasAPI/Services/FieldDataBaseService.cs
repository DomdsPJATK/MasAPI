using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using MasAPI.DTOs.Requests;
using MasAPI.DTOs.Responses;
using MasAPI.Models;
using MasAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MasAPI.Services
{
    public class FieldDataBaseService : IFieldDataBaseService
    {
        private readonly DataBaseContext _context;

        public FieldDataBaseService(DataBaseContext context)
        {
            _context = context;
        }

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

            if (address == null) return new NotFoundResult(); //Walidacja czy adres istnieje

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

        public async Task<IActionResult> GetTermsForDate(TermsRequest request)
        {    
            List<TermsResponse> terms = new List<TermsResponse>()
            {
                new TermsResponse()
                {
                    dateSince = new DateTime(request.Date.Year,request.Date.Month, request.Date.Day, 8,0,0),
                    dateUntil = new DateTime(request.Date.Year,request.Date.Month, request.Date.Day, 11,0,0)
                },
                new TermsResponse()
                {
                    dateSince = new DateTime(request.Date.Year,request.Date.Month, request.Date.Day, 11,0,0),
                    dateUntil = new DateTime(request.Date.Year,request.Date.Month, request.Date.Day, 14,0,0)
                },
                new TermsResponse()
                {
                    dateSince = new DateTime(request.Date.Year,request.Date.Month, request.Date.Day, 14,0,0),
                    dateUntil = new DateTime(request.Date.Year,request.Date.Month, request.Date.Day, 17,0,0)
                },
                new TermsResponse()
                {
                    dateSince = new DateTime(request.Date.Year,request.Date.Month, request.Date.Day, 17,0,0),
                    dateUntil = new DateTime(request.Date.Year,request.Date.Month, request.Date.Day, 20,0,0)
                }
            };
            
            List<TermsResponse> busyTerms = new List<TermsResponse>();
            
            List<TermsResponse> freeTerms = new List<TermsResponse>();

            var field = await _context.Fields.Where(p => p.FieldId == request.FieldId).FirstOrDefaultAsync();
            
            if(field == null) return new NotFoundResult();
            
            var matches = _context.Matches.Where(p => p.FieldId == request.FieldId && p.DateSince.Day == request.Date.Day && p.DateSince.Month == request.Date.Month && p.DateSince.Year == request.Date.Year);
            var trainings = _context.Trainings.Where(p => p.FieldId == request.FieldId && p.DateSince.Day == request.Date.Day && p.DateSince.Month == request.Date.Month && p.DateSince.Year == request.Date.Year);

            foreach (var match in matches)
            {
                busyTerms.Add(new TermsResponse()
                {
                    dateSince = match.DateSince,
                    dateUntil = match.DateUntil
                });
            }
            
            foreach (var training in trainings)
            {
                busyTerms.Add(new TermsResponse()
                {
                    dateSince = training.DateSince,
                    dateUntil = training.DateUntil
                });
            }

            foreach (var term in terms)
            {
                var isReserved = false;
                foreach (var busyTerm in busyTerms)
                {
                    if (term.dateSince.Hour == busyTerm.dateSince.Hour) isReserved = true;
                }
                
                if(!isReserved) freeTerms.Add(term);
            }
            
            return new OkObjectResult(freeTerms);

        }

        
    }
}