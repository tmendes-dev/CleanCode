using System;
using System.Linq;

namespace CleanCode.PoorMethodSignatures
{
    public class PoorMethodSignatures
    {
        public void Run()
        {
            UserService userService = new UserService();

            User user = userService.Login("username", "password");
            User anotherUser = userService.GetUser("username");
        }
    }

    public class UserService
    {
        private UserDbContext _dbContext = new UserDbContext();

        public User GetUser(string username)
        {
            User user = _dbContext.Users.SingleOrDefault(u => u.Username == username);
            return user;
        }

        public User Login(string username, string password)
        {
            User user = _dbContext.Users.SingleOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                user.LastLogin = DateTime.Now;
            }
            return user;
        }
    }

    public class UserDbContext : DbContext
    {
        public IQueryable<User> Users { get; set; }
    }

    public class DbSet<T>
    {
    }

    public class DbContext
    {
    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime LastLogin { get; set; }
    }
}