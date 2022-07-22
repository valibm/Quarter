using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Identity
{
    public class UserSocials : IEntity
    {
        public int Id { get; set; }
        public string FacebookLink { get; set; }
        public string TwitterLink { get; set; }
        public string LinkedInLink { get; set; }
    }
}
