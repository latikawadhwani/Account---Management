using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;

namespace BO
{
    public class TransactionBO:ITransactionBO
    {
        public DateTime StartDate { get; set; }
        public int AccountID { get; set; }
        public int TransactionID { get; set; }
        public int Credit { get; set; }
        public int Debit { get; set; }
        public int Balance { get; set; }

    }
}
