using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.ViewModels
{
    public class AccountDetailsVM
    {
        [Required, MinLength(10), MaxLength(400)]
        public string Information { get; set; }
        [Required, MinLength(10), MaxLength(100)]
        public string SubInformation { get; set; }

        [Required, Range(1, 70)]
        public double Experience { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string Location { get; set; }
        [Required, MinLength(5), MaxLength(50)]
        public string PracticeArea { get; set; }

        [DataType(DataType.Url)]
        public string FacebookLink { get; set; }
        [DataType(DataType.Url)]
        public string TwitterLink { get; set; }
        [DataType(DataType.Url)]
        public string LinkedInLink { get; set; }

        public int PositionId { get; set; }
        public IFormFile ImageFile { get; set; }

    }
}
