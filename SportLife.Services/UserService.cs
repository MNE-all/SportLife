using SportLife.Context;
using SportLife.Context.Models;

namespace SportLife.Services
{
    public class UserService 
    {
        SportLifeContext db;
        public UserService(SportLifeContext sportLifeContext)
        {
            sportLifeContext.Exercise.Add(new Exercise());
            db = sportLifeContext;
            db.SaveChanges();
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

        public IEnumerable<User> GetUsers()
        {
            return db.Users.ToList();
        }
    }
}
