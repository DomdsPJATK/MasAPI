using System;

namespace MasAPI.DTOs.Requests
{
    public class MatchRequest
    {
        public int TeamId { get; set; }
        public int FieldId { get; set; }
        public DateTime DateSince { get; set; }
        public DateTime DateUntil { get; set; }
        public string EnemyName { get; set; }
        public string Status { get; set; }
    }
}