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
         return ((ITransactionManager)_Account).Credit(amount);
      }

      public int WithDraw(int pin, decimal amount)
      {
         if (_Pin == pin)
         {
            return ((ITransactionManager)_Account).Debit(amount);
         }
         throw new ArgumentException("INVALIDE_PIN");
      }
   }
}
