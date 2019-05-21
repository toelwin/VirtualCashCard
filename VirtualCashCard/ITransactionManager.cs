using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualCashCard
{
   internal interface ITransactionManager
   {
      int Credit(decimal amount);
      int Debit(decimal amount);
   }
}
