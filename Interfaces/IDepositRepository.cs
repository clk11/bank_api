using Bank.Entities;

namespace Bank.Interfaces
{
    public interface IDepositRepository
    {
        List<Deposit> GetAll();
        void AddDeposit(Deposit d);
        void EditDeposit(Deposit d);
        Deposit GetDeposit(int id);
    }
}
