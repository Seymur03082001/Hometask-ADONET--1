using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONET_Context.Abstractions
{
    internal interface IService<T>
    {
        void Create(T model);
        List<T> GetAll();
        void Delete(int id);
        void Update(T model);
        T GetByID(int id);
    }
}
