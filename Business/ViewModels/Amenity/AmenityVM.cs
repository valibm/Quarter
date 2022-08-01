using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ViewModels
{
    public class AmenityVM
    {
        public int AmenityId { get; set; }
        public string AmenityName { get; set; }
        public int PropertyTypeId { get; set; }
        public bool Selected { get; set; }
    }
}
