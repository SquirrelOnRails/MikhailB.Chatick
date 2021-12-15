using MikhailB.Chatick.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikhailB.Chatick.Contracts.Interfaces
{
    public interface ITokenRepository
    {
        Token Get(Guid uid);
        Token Get(string tokenValue);
        Task<Token> Update(Token token);
        Task<Token> Add(Token token);
    }
}
