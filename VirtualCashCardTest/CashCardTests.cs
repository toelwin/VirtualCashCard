using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualCashCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace VirtualCashCard.Tests
{
   [TestClass()]
   public class CashCardTests
   {

      [TestMethod()]
      public void Topup_Successful()
      {
         var initBalance = 100;
         IAccount account = new CashAccount("1234123412341234", initBalance);         
         ICard card = new CashCard(account, 1234);
         
         decimal topUpVal = 100;
         var retVal = card.Topup(topUpVal);

         Assert.IsTrue(account.Balance == (initBalance + topUpVal));            

      }

      [TestMethod()]
      public void WithDrawal_Successful_On_Valid_Pin()      {
         var initBalance = 100;
         IAccount account = new CashAccount("1234123412341234", initBalance);
         ICard card = new CashCard(account, 1234);
         var retVal = card.WithDraw(1234, 5);
         Assert.IsTrue(retVal == 0);
      }

      [TestMethod()]
      [ExpectedException(typeof(ArgumentException), "INVALID_PIN")]
      public void WithDrawal_Failed_On_Invalid_Pin()
      {
         var initBalance = 100;
         IAccount account = new CashAccount("1234123412341234", initBalance);
         ICard card = new CashCard(account, 1234);

         var retVal = card.WithDraw(9999, 5);
      }

      [TestMethod()]
      public void Parallel_WithDrawals_Failed_After_Funds_Runout()
      {
         var initBalance = 100;
         IAccount account = new CashAccount("1234123412341234", initBalance);
         ICard card = new CashCard(account, 1234);

         int total = 0;

         Parallel.For(0, 10, () => 0, (i, loop, subtotal) => {
            subtotal += card.WithDraw(1234, 20);
            return subtotal;
            },
            (x) => {
               Interlocked.Add(ref total, x);
            }
         );
         
         
         Assert.IsTrue(total == -5);
      }


      [TestMethod()]
      public void WithDraw_Successful_On_Sufficient_Fund()
      {
         IAccount account = new CashAccount("1234123412341234", 100);
         ICard card = new CashCard(account, 1234);
         var retVal = card.WithDraw(1234, 5);
         Assert.IsTrue(retVal == 0);
      }


      [TestMethod()]
      public void WithDraw_Failed_On_Insufficient_Fund()
      {
         IAccount account = new CashAccount("1234123412341234", 100);
         ICard card = new CashCard(account, 1234);
         var retVal = card.WithDraw(1234, 200);
         Assert.IsFalse(retVal == 0);
      }

   }
}