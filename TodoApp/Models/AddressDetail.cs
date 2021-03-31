using System;
using System.Collections.Generic;

#nullable disable

namespace TodoApp.Models
{
    public partial class AddressDetail
    {
        public long AddressDetailId { get; set; }
        public long UserDetailId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Postal { get; set; }
        public long? CountryId { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public Guid? Guid { get; set; }

        public virtual Country Country { get; set; }
        public virtual UserDetail UserDetail { get; set; }
    }
}
