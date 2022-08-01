using DAL.Entity;
using DAL.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public bool IsAllowed { get; set; }

        public int? BlogId { get; set; }
        public Blog Blog { get; set; }

        public int? ProductId { get; set; }
        public Product Product { get; set; }
    }
}
