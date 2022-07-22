using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Identity
{
    public class UserDetails : IEntity
    {
        public int Id { get; set; }
        public string Positions { get; set; }
        public int Experience { get; set; }
        public string Location { get; set; }
        public string PracticeArea { get; set; }
    }
}
