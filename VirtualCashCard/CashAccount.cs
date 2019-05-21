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
         lock (this)
         {

            this.Balance += amount;

         }
         return 0;
      }

      public int Debit(decimal amount)
      {
         lock (this)
         {
            if (this.Balance < amount) return -1;  // Insufficient Fund

            this.Balance -= amount;
         }
         return 0;
      }
   }


}
