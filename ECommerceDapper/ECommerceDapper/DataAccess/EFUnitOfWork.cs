using System;
using System.Collections.Generic;
using static System.Configuration.ConfigurationManager;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceDapper.Domain.Abstractions;

namespace ECommerceDapper.DataAccess
{
    public class EFUnitOfWork : IUnitOfWork
    {
        IAdminRepository IUnitOfWork.AdminRepository => new EFAdminRepository();

        IUserRepository IUnitOfWork.UserRepository => new EFUserRepository();

        IOrderRepository IUnitOfWork.OrderRepository => new EFOrderRepository();

        IProductRepository IUnitOfWork.ProductRepository => new EFProductRepository();
    }
}
