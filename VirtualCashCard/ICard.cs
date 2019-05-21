using System;

namespace VirtualCashCard
{
    public interface ICard
    {   
      int WithDraw(int pin,decimal amount);
      int Topup(decimal amount);
   }
}
