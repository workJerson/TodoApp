using System;
using System.Collections.Generic;

#nullable disable

namespace TodoApp.Models
{
    public partial class UserDetail
    {
        public UserDetail()
        {
            AddressDetails = new HashSet<AddressDetail>();
            ContactDetails = new HashSet<ContactDetail>();
        }

        public long UseDetailId { get; set; }
        public long? UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Occupation { get; set; }
        public string Nationality { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public Guid? Guid { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<AddressDetail> AddressDetails { get; set; }
        public virtual ICollection<ContactDetail> ContactDetails { get; set; }
    }
}
