using System;
using System.Collections.Generic;

#nullable disable

namespace TodoApp.Models
{
    public partial class Country
    {
        public Country()
        {
            AddressDetails = new HashSet<AddressDetail>();
        }

        public long CountryId { get; set; }
        public string CountryCode { get; set; }
        public string Name { get; set; }
        public string CurrencyCode { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public Guid Guid { get; set; }

        public virtual ICollection<AddressDetail> AddressDetails { get; set; }
    }
}
