using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;
using BO;

namespace FactoryPatternBO
{
   public class LoginBOFactory
    {
        static ILoginDetailsBO bo = null;
        public static ILoginDetailsBO CreateInstance()
        {
            if (bo == null)
                bo = new LoginDetailsBO();
            return bo;
        }
    }
}
