using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;
using BO;

namespace FactoryPatternBO
{
   public class TransactionBOFactory
    {
        static ITransactionBO bo = null;
        public static ITransactionBO CreateInstance()
        {
            if (bo == null)
                bo = new TransactionBO();
            return bo;
        }
    }
}
