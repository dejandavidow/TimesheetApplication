using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class PersistentProject
    {
        public int Id { get; set; }
        public string? ProjectName { get; set; }
        public string? Description { get; set; }
        public string? Archive { get; set; }
        public string? Status { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; } = null!;
        public int MemberId { get; set; }
        public Member Member { get; set; } = null!;
    }
}
