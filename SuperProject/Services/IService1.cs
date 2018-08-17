using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public interface IService1<T>
        where T : class
    {
        bool Create(T obj);
        List<T> Read();
        bool Update(string key, T obj);
        bool Delete(string key);
    }
}
