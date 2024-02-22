using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ElnetFirstAct.Models;

namespace ElnetFirstAct.Data
{
    public class DBHelper : DbContext
    {
        public DBHelper(DbContextOptions<DBHelper> options) : base(options)
        {

        }

        public DbSet<UserModel> User { get; set; }

        public UserModel GetUserByEmail(string email) 
        {
            if (email == null){
  
                throw new ArgumentException("Email cannot be null.");
            }

            // Query the User DbSet to find a user with the specified email
            return User.FirstOrDefault(user => user.Email == email);
        }
    }
}
