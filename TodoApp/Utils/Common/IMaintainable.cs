using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.Utils.Common
{
    public interface IMaintainable<T>
    {
        Task<List<T>> List();
        Task<(T, string[])> Show(Guid Guid);
        Task<(T, string[])> Create(T modelObject);
        Task<(List<T>, string[])> Create(List<T> modelObjects);
        Task<(T, string[])> Update(T modelObject);
        Task<(int, string[])> Delete(Guid Guid);
    }
}
