using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.ViewModels
{
    public class AccountDetailsVM
    {
        [Required]
        public string Information { get; set; }
    }
}
