using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publico_Kommunikation_Project.DataAccess
{
    public interface ICompositeKeyRepository<T> : IRepository<T> where T : class
    {
        T GetByKey(int key1, int key2);
        void Delete(int key1, int key2);
    }
}
