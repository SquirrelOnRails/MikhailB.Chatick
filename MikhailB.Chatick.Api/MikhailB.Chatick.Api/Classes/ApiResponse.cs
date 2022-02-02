using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MikhailB.Chatick.Api.Classes
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }
    }
}
