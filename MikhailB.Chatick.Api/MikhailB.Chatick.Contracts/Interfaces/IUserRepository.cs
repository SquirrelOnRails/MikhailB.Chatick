using MikhailB.Chatick.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikhailB.Chatick.Contracts.Interfaces
{
    public interface IUserRepository
    {
        User Get(string username);
        Task<User> Add(User user);
        Task<User> Update(User user);
        Task Delete(User user);
    }
}
