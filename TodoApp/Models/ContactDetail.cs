using System;
using System.Collections.Generic;

#nullable disable

namespace TodoApp.Models
{
    public partial class ContactDetail
    {
        public long ContactDetailId { get; set; }
        public long? UserId { get; set; }
        public string Prefix { get; set; }
        public string ContactNumber { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public Guid Guid { get; set; }

        public virtual User User { get; set; }
    }
}
