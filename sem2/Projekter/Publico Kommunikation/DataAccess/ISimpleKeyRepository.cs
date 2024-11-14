using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publico_Kommunikation_Project.DataAccess
{
    public interface ISimpleKeyRepository<T> : IRepository<T> where T : class
    {
        T GetById(int id);
        void Delete(int id);
    }
}
