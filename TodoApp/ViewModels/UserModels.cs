using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.ViewModels
{
    public class UserModelBase
    {
        public string Email { get; set; }
        public string Username { get; set; }
    }

    public class CreateUserModel : UserModelBase
    {
        public CreateUserDetailsModel UserDetail { get; set; }
        public ICollection<CreateAddressDetailModel> AddressDetails { get; set; }
        public ICollection<CreateContactDetailModel> ContactDetails { get; set; }
    }
    public class UpdateUserModel : UserModelBase
    {
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public Guid Guid { get; set; }
        public int LoginAttempts { get; set; }
        public string Status { get; set; }
    }
    public class GetUserModel : UpdateUserModel
    {
        public GetUserDetailsModel UserDetail { get; set; }
        public ICollection<GetAddressDetailModel> AddressDetails { get; set; }
        public ICollection<GetContactDetailModel> ContactDetails { get; set; }
    }
}
