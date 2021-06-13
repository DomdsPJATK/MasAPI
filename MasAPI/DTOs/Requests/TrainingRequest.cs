using System;
using MasAPI.Models;

namespace MasAPI.DTOs.Requests
{
    public class TrainingRequest
    {
        public int TeamId { get; set; }
        public int FieldId { get; set; }
        public DateTime DateSince { get; set; }
        public DateTime DateUntil { get; set; }
    }
}