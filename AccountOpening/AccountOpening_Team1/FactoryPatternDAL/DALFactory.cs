using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;
using DAL;


namespace FactoryPatternDAL
{
    public class DALFactory
    {
        static IAccountDAL dal = null;
        public static IAccountDAL CreateInstance()
        {
            if (dal == null)
                dal = new AccountDAL();
            return dal;
        }
    }
}
