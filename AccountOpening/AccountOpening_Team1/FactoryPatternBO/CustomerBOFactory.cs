using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;
using BO;

namespace FactoryPatternBO
{
    public class CustomerBOFactory
    {
        static ICustomerDetailsBO bo = null;
        public static ICustomerDetailsBO CreateInstance()
        {
            if (bo == null)
                bo = new CustomerDetailsBO();
            return bo;
        }
    }
}
