using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Utils.Response;

namespace TodoApp.Utils.Common
{
    public interface IServiceMaintainable<T, X, Y, Z>
    {
        Task<GenericResponse<Z>> GetAll();
        Task<GenericResponse<T>> Get(Guid Guid);
        Task<GenericResponse<T>> Create(X obj);
        Task<GenericResponse<T>> Update(Y modelObject);
        Task<GenericResponse<T>> Delete(Guid Guid);
    }
}
