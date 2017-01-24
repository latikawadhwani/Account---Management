using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;
using BLL;


namespace FactoryPatternBLL
{
    public class BLLFactory
    {
        static IAccountBLL bll = null;
        public static IAccountBLL CreateInstance()
        {
            if (bll == null)
                bll = new AccountBLL();
            return bll;
        }
    }
}
