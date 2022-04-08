using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCatalogue.BLL.Interfaces
{
    public interface IDTORepository<T> 
        where T : class
    {
        void Add(T entry);
        void Edit(T entry);
        void Delete(T entry);
        T Get(int? id);
        IList<T> GetAll();
    }
}
