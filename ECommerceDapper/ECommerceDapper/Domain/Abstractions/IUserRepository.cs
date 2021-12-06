using ECommerceDapper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDapper.Domain.Abstractions
{
    public interface IUserRepository : IRepository<User>
    {
        int AddUser(User user);
        int GetById(string user);
    }
}
