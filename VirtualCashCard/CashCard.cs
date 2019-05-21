using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualCashCard
{
   public class CashCard : ICard
   {
      private int _Pin;
      private IAccount _Account;
      public CashCard(IAccount account, int pin)
      {
         _Pin = pin;
         _Account = account;
      }

      public int Topup(decimal amount)
      {
         throw new NotImplementedException();
      }

      public int WithDraw(int pin, decimal amount)
      {
         throw new NotImplementedException();
      }
   }
}
