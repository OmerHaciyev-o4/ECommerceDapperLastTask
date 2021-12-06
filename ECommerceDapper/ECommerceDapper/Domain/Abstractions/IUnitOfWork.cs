using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDapper.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        IAdminRepository AdminRepository { get; }
        IUserRepository UserRepository { get; }
        IOrderRepository OrderRepository { get; }
        IProductRepository ProductRepository { get; }
    }
}
