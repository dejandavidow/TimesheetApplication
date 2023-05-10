using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class ClientDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string? ClientName { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Adress { get; set; }
        [Required]
        [MaxLength(100)]
        public string? City { get; set; }
        [Required]
        [MaxLength(100)]
        public string? PostalCode { get; set; }
    }
}

