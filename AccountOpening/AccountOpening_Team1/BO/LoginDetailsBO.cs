using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;

namespace BO
{
   public class LoginDetailsBO:ILoginDetailsBO
    {
        public string userID { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string loginDate { get; set; }
        public string loginTime { get; set; }
        public string loginIP { get; set; }
        public string NewPassword { get; set; }
        public string SecretQuestion { get; set; }
        public string Answer { get; set; }
    }
}
