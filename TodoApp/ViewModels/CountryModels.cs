using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.ViewModels
{
    public class CreateCountryModel
    {
        public string CountryCode { get; set; }
        public string Name { get; set; }
        public string CurrencyCode { get; set; }
    }
    public class UpdateCountryModel : CreateCountryModel
    {
        public string Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public Guid? Guid { get; set; }
    }
    public class GetCountryModel : UpdateCountryModel
    {
    }
}
