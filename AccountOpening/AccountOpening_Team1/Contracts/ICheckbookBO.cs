using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contracts
{
    public interface ICheckbookBO
    {
        int RequestID { get; set; }
        int AccountID { get; set; }
        int CheckBookNum { get; set; }
        DateTime RequestDate { get; set; }
        string Status { get; set; }
    }
}
