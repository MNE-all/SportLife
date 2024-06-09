using System.IdentityModel.Tokens.Jwt;
using SportLife.Context;
using SportLife.Context.Models;
using System.Runtime.InteropServices;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using SportLife.Services.Secrets;

namespace SportLife.Services
{
    public class UserService 
    {
        SportLifeContext db;
        public UserService(SportLifeContext sportLifeContext)
        {
            db = sportLifeContext;
        }
        public User? Create(string login, string password)
        {
            var result = db.Users.Add(new User { Login = login, Password = password }).Entity;
            try
            {
                db.SaveChanges();
                return result;
            }
            catch
            {
                return null;
            }
        }

        public User? GetUserById(Guid id)
        {
            return db.Users.FirstOrDefault(u => u.Id == id);
        }
        
        public IEnumerable<User> GetUsers()
        {
            return db.Users.ToList();
        }

        public string Login(string login, string password)
        {
            var user = db.Users.FirstOrDefault(u => u.Login == login);
            if (user != null)
            {
                if (user.Password == password)
                {
                    var claims = new List<Claim> {new Claim(ClaimsIdentity.DefaultNameClaimType, user.Id.ToString()) };
                    // создаем JWT-токен
                    var jwt = new JwtSecurityToken(
                        issuer: AuthOptions.ISSUER,
                        audience: AuthOptions.AUDIENCE,
                        claims: claims,
                        expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(15)),
                        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            
                    return new JwtSecurityTokenHandler().WriteToken(jwt);
                }
            }

            return null;
        }

        public string ShowPassword(Guid id)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == id);
            return user != null ? user.Password : null;
        }
    }
}
