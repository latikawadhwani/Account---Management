using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;
using BO;

namespace FactoryPatternBO
{
   public class VisitorBOFactory
    {
        static IVisitorBO bo = null;
        public static IVisitorBO CreateInstance()
        {
            if (bo == null)
                bo = new VisitorBO();
            return bo;
        }
    }
}
