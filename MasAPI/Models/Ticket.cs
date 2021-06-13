namespace MasAPI.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public int SeatNumber { get; set; }

        public int MatchId { get; set; }
        public Match Match { get; set; }
    }
}