using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.ViewModels
{
    public class AccountDetailsVM
    {
        public string Information { get; set; }
        public string SubInformation { get; set; }

        public double Experience { get; set; }
        public string Location { get; set; }
        public string PracticeArea { get; set; }

        public string FacebookLink { get; set; }
        public string TwitterLink { get; set; }
        public string LinkedInLink { get; set; }

        public int PositionId { get; set; }

        public IFormFile ImageFile { get; set; }

    }
}
