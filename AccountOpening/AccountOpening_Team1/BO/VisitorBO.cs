using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;

namespace BO
{
  public  class VisitorBO:IVisitorBO
    {
        public string VisitorName{get;set;}
        public string VisitorEmail{get;set;}
        public string ContactNo{get;set;}
    }
}
