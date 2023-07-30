using Bank.Entities;

namespace Bank.Interfaces
{
    public interface ICoinRepository
    {
        List<Coin> GetAll();
        void AddCoin(Coin c);
        void DeleteCoin(int id);
        Coin GetCoin(int id);
        void EditCoin(Coin c);
    }
}
