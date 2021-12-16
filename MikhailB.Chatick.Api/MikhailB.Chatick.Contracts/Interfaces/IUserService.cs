using MikhailB.Chatick.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikhailB.Chatick.Contracts.Interfaces
{
    public interface IUserService
    {
        User SearchByUsername(string username);
        Task<User> RegisterUser(User newUser);
    }
}
