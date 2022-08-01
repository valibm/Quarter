using DAL.Entity;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Identity
{
    public class AppUser : IdentityUser, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Information { get; set; }
        public string SubInformation { get; set; }

        public double? Experience { get; set; }
        public string Location { get; set; }
        public string PracticeArea { get; set; }

        public string FacebookLink { get; set; }
        public string TwitterLink { get; set; }
        public string LinkedInLink { get; set; }

        public int? ImageId { get; set; }
        public Image Image { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        public int? PositionId { get; set; }
        public Position Position { get; set; }
    }
}
