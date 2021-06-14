namespace MasAPI.DTOs.Requests
{
    public class ChangeStatusRequest
    {
        public int MatchId { get; set; }
        public string Status{ get; set; }
    }
}