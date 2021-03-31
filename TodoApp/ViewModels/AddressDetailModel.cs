using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.ViewModels
{
    public class CreateAddressDetailModel
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Postal { get; set; }
        public long? CountryId { get; set; }
    }
    public class UpdateAddressDetailModel : CreateAddressDetailModel
    {
        public string Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public Guid? Guid { get; set; }
    }

    public class GetAddressDetailModel : UpdateAddressDetailModel
    {
        public GetCountryModel Country { get; set; }
    }
}
