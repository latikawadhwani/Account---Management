using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contracts
{
   public interface IVisitorBO
    {
         string VisitorName { get; set; }
         string VisitorEmail { get; set; }
         string ContactNo { get; set; }
    }
}
