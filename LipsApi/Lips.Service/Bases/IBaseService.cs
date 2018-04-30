using Lips.Dto.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Service.Bases
{
    public interface IBaseService<T> where T : BaseDto
    {
        List<T> GetAll();
        T Get(long id);
        T Create(T item);
        T Update(T item);
        T CreateOrUpdate(T item);
    }
}
