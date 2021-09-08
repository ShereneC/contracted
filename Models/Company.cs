using System.ComponentModel.DataAnnotations;

namespace contracted.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}