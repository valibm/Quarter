using DAL.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Area : IEntity
    {
        public int Id { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string Name { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }

        public List<Product> Products { get; set; }
    }
}
