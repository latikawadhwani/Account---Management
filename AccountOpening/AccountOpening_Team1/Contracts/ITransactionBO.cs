using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contracts
{
   public interface ITransactionBO
    {
       DateTime StartDate { get; set; }
        int AccountID { get; set; }
         int TransactionID { get; set; }
         int Credit { get; set; }
         int Debit { get; set; }
         int Balance { get; set; }
    }
}
