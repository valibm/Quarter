using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Identity
{
    public class UserInformation : IEntity
    {
        public int Id { get; set; }
        public string Information { get; set; }
        public string SubInformation { get; set; }

        public int UserDetailsId { get; set; }
        public UserDetails UserDetails { get; set; }

        public int UserSocialsId { get; set; }
        public UserSocials UserSocials { get; set; }
    }
}
