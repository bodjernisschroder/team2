using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publico_Kommunikation_Project.DataAccess
{
    public interface ISimpleKeyRepository<T> : IRepository<T> where T : class
    {
        T GetByKey(int key);
        void Delete(int key);
    }
}
