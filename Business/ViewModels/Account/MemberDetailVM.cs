using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ViewModels.Account
{
    public class MemberDetailVM
    {
        public string Information { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
