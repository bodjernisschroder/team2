using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.DataAccess
{
    public interface IRepository<T>
    {
        void Add(T obj);
        void Remove(T obj);
    }
}
