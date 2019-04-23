using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrochetteEnMousse.Services.Interface
{
    public interface ICrudTest<T>
    {
        Task<List<T>> Index();
        Task<T> Details(string id);
        Task Create();
        Task Create(T obj);
        Task Update();
        Task Update(string id, T obj);
        Task Delete(string id);
        Task DeleteConfirmed(T obj);
    }
}
