using Bank.Entities;
using Bank.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Bank.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public AuthRepository(ApplicationDbContext context,IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }

        public string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,user.Username)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        public string Login(User user)
        {
            var item = _context.Users.FirstOrDefault(x => x.Username == user.Username);
            if(item!=null){
                if (!BCrypt.Net.BCrypt.Verify(user.Password, item.Password)) return "bad";
                else
                    return CreateToken(user);
            }
            return "bad";
        }

        public string Register(User user)
        {
            if(_context.Users.FirstOrDefault(x => x.Username == user.Username) == null)
            {
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
                user.Password = passwordHash;
                _context.Users.Add(user);
                _context.SaveChanges();
                return "good";
            }
            return "bad";
        }

    }
}
