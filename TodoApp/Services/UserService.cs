using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Repositories;
using TodoApp.Utils.Response;

namespace TodoApp.Services
{
    public interface IUserService
    {
        Task<GenericResponse<>> GetAllUsers();
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
    }
}
