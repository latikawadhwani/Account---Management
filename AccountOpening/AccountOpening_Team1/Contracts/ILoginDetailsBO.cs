using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contracts
{
  public  interface ILoginDetailsBO
    {
      string userID { get; set; }
      string Password { get; set; }
      string Role { get; set; }
    string loginDate { get; set; }
   string loginTime { get; set; }
      string loginIP { get; set; }
       string NewPassword { get; set; }
       string SecretQuestion { get; set; }
      string Answer { get; set; }
      
    }
}
