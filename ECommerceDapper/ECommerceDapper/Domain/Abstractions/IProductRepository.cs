using ECommerceDapper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDapper.Domain.Abstractions
{
    public interface IProductRepository : IRepository<Product>
    {
        int ProductAdd(Product product);
        int ProductUpdate(Product product);
        int ProductDelete(int id);
    }
}
