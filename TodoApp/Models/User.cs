using System;
using System.Collections.Generic;

#nullable disable

namespace TodoApp.Models
{
    public partial class User
    {
        public User()
        {
            AddressDetails = new HashSet<AddressDetail>();
            ContactDetails = new HashSet<ContactDetail>();
        }

        public long UserId { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? LoginAttempts { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public Guid Guid { get; set; }

        public virtual UserDetail UserDetail { get; set; }
        public virtual ICollection<AddressDetail> AddressDetails { get; set; }
        public virtual ICollection<ContactDetail> ContactDetails { get; set; }
    }
}
