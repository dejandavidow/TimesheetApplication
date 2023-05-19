
namespace Domain.Entities
{
    public class Project
    {

        public int Id { get; set; }
        public string? ProjectName { get; set; }
        public string? Description { get; set; }
        public string? Archive { get; set; }
        public string? Status { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; } = null!;
    }
}
