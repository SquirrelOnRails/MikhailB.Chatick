using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MikhailB.Chatick.Api.Classes
{
    public class UserDisplayInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }

        public string FullName { get { return $"{LastName} {FirstName}"; } }
    }
}
