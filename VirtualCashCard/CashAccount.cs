using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualCashCard
{
    public class CashAccount : IAccount
   {
      public string AccountNumber { get; private set; }      
      public decimal Balance { get; private set; }

      public CashAccount(string accountNumber, decimal openingBalance)
      {
         AccountNumber = accountNumber;
         Balance = openingBalance;
      }
            

      public int Credit(decimal amount)
      {
         throw new NotImplementedException();
      }

      public int Debit(decimal amount)
      {
         throw new NotImplementedException();
      }
   }


}
