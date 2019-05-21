namespace VirtualCashCard
{
   public interface IAccount
   {
      string AccountNumber { get; }
      decimal Balance { get; }
      int Credit(decimal amount);
      int Debit(decimal amount);
   }

}