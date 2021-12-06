using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDapper.Domain.Abstractions 
{ 
    public interface IRepository<T>
    {
        List<T> GetAllData();
        int GetById(string data);
    }
}