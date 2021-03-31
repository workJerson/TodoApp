using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.ViewModels
{
    public class CreateContactDetailModel
    {
        public string Prefix { get; set; }
        public string ContactNumber { get; set; }
    }
    public class UpdateContactDetailModel : CreateContactDetailModel
    {
        public string Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public Guid? Guid { get; set; }

    }
    public class GetContactDetailModel : UpdateContactDetailModel
    {

    }
}
