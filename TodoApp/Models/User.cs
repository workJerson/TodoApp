using System;
using System.Collections.Generic;

#nullable disable

namespace TodoApp.Models
{
    public partial class User
    {
        public User()
        {
            UserDetails = new HashSet<UserDetail>();
        }

        public long UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? LoginAttempts { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public Guid? Guid { get; set; }

        public virtual ICollection<UserDetail> UserDetails { get; set; }
    }
}
