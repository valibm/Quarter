using DAL.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Identity
{
    public class AppUser : IdentityUser, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int? UserInformationId { get; set; }
        public UserInformation UserInformation { get; set; }
    }
}
