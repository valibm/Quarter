using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.ViewModels.Account
{
    public class MemberDetailVM
    {
        [Required, MinLength(10), MaxLength(400)]
        public string Information { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
