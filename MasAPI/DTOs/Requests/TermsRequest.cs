using System;

namespace MasAPI.DTOs.Requests
{
    public class TermsRequest
    {
        public DateTime Date { get; set; }
        public int FieldId { get; set; }
    }
}