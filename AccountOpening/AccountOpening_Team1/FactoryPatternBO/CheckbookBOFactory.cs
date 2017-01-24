using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;
using BO;

namespace FactoryPatternBO
{
   public class CheckbookBOFactory
    {
       static ICheckbookBO cbo = null;
       public static ICheckbookBO CreateInstance()
        {
            if (cbo == null)
                cbo = new CheckbookBO();
            return cbo;
        }
    }
}
