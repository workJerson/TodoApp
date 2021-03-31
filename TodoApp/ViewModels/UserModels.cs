using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.ViewModels
{
    public class CreateUserModel
    {
        public string Username { get; set; }
        public int LoginAttempts { get; set; }
        public string Status { get; set; }
    }
    public class UpdateUserModel : CreateUserModel
    {
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public Guid? Guid { get; set; }
    }
    public class GetUserModel : UpdateUserModel
    {
        public ICollection<GetUserDetailsModel> UserDetails { get; set; }
    }
}
