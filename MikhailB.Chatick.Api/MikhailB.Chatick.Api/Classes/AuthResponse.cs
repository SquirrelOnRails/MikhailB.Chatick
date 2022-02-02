using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MikhailB.Chatick.Api.Classes
{
    public class AuthResponse : ApiResponse
    {
        public string Token { get; set; }
    }
}
