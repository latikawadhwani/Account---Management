using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;

namespace BO
{
   public class CheckbookBO:ICheckbookBO
    {
       public int RequestID { get; set; }
       public int AccountID { get; set; }
       public int CheckBookNum { get; set; }
       public DateTime RequestDate { get; set; }
       public string Status { get; set; }
    }
}
