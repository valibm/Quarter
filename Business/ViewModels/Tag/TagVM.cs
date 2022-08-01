using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ViewModels
{
    public class TagVM
    {
        public int TagId { get; set; }
        public string TagName { get; set; }
        public bool Selected { get; set; }
    }
}
