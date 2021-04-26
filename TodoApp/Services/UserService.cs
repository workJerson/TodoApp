using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Repositories;
using TodoApp.Utils.Common;
using TodoApp.Utils.Response;
using TodoApp.ViewModels;
using TodoApp.Models;
namespace TodoApp.Services
{
    public interface IUserService : IServiceMaintainable<GetUserModel, CreateUserModel, UpdateUserModel, List<GetUserModel>>
    {

    }

    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        public dynamic ViewModel;
        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<GenericResponse<GetUserModel>> Create(CreateUserModel obj)
        {
            var payload = mapper.Map<User>(obj);
            var result = await userRepository.Create(payload);

            if (result.Item2 != null)
            {
                return new GenericResponse<GetUserModel>(null, result.Item2.Select(e => new ErrorField("message", e)).ToList(), "Error on creating user.", 400);
            }

            return new GenericResponse<GetUserModel>(mapper.Map<GetUserModel>(result.Item1), "User created successfully.", 200);
        }

        public async Task<GenericResponse<GetUserModel>> Delete(Guid Guid)
        {
            var result = await userRepository.Delete(Guid);

            if (result.Item2 != null)
            {
                return new GenericResponse<GetUserModel>(null, result.Item2.Select(e => new ErrorField("message", e)).ToList(), "Error on deleting user.", 400);
            }

            return new GenericResponse<GetUserModel>(mapper.Map<GetUserModel>(result.Item1), "User deleted successfully.", 200);
        }

        public async Task<GenericResponse<GetUserModel>> Get(Guid guid)
        {
            var result = await userRepository.Show(guid);

            if (result.Item2 != null)
            {
                return new GenericResponse<GetUserModel>(null, result.Item2.Select(e => new ErrorField("message", e)).ToList(), "Error on retreiving user.", 400);
            }

            return new GenericResponse<GetUserModel>(mapper.Map<GetUserModel>(result.Item1), "User retreived successfully.", 200);
        }

        public async Task<GenericResponse<List<GetUserModel>>> GetAll()
        {
            var result = await userRepository.List();

            return new GenericResponse<List<GetUserModel>>(mapper.Map<List<GetUserModel>>(result), "Users retreived successfully.", 200);
        }

        public async Task<GenericResponse<GetUserModel>> Update(UpdateUserModel modelObject)
        {
            var user = new User
            {
                Guid = modelObject.Guid,
                Username = modelObject.Username,
                LoginAttempts = modelObject.LoginAttempts,
                Status = modelObject.Status
            };

            var result = await userRepository.Update(user);

            if (result.Item2 != null)
            {
                return new GenericResponse<GetUserModel>(null, result.Item2.Select(e => new ErrorField("message", e)).ToList(), "Error on updating  user.", 400);
            }

            return new GenericResponse<GetUserModel>(mapper.Map<GetUserModel>(result.Item1), "User updated successfully.", 200);

        }
    }
}
