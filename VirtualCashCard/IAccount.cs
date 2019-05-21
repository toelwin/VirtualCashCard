namespace VirtualCashCard
{
   public interface IAccount
   {
      string AccountNumber { get; }
      decimal Balance { get; }
      int Debit(decimal amount);
      int Credit(decimal amount);
   }

}