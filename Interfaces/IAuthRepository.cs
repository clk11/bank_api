using Bank.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Interfaces
{
    public interface IAuthRepository
    {
        public string Register(User user);
        public string Login(User user);
        public string CreateToken(User user);
    }
}
