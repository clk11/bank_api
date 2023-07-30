using Bank.Entities;
using Bank.Interfaces;
using Bank.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuthController:ControllerBase
    {
        private readonly AuthRepository _authRepository;
        public AuthController(AuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        [HttpPost]
        public string Register([FromBody] User user)
        {
            return _authRepository.Register(user);
        }
        [HttpPost]
        public string Login([FromBody] User user)
        {
            return _authRepository.Login(user);
        }
    }    
}
