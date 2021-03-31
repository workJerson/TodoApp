using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.ViewModels
{
    public class CreateUserDetailsModel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Occupation { get; set; }
        public string Nationality { get; set; }
    }
    public class UpdateUserDetailsModel : CreateUserDetailsModel
    {
        public string Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public Guid? Guid { get; set; }
    }
    public class GetUserDetailsModel : UpdateUserDetailsModel
    {
        public ICollection<GetAddressDetailModel> AddressDetails { get; set; }
        public ICollection<GetContactDetailModel> ContactDetails { get; set; }
    }
}
