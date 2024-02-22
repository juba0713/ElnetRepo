using ElnetFirstAct.Data;
using ElnetFirstAct.Models;
using Microsoft.AspNetCore.Mvc;
using BCrypt.Net;
using Microsoft.AspNetCore.Html;

namespace ElnetFirstAct.Controllers
{
    public class FBController : Controller
    {
        private readonly DBHelper _dbHelper;

        public FBController(DBHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return PartialView("Login");
        }

        [HttpPost]
        public IActionResult Login(LoginDto inDto)
        {
            Boolean isUserExist = validateLogin(inDto);

            if (!isUserExist)
            {
                TempData["LoginError"] = "Error: Invalid Email or Password";

                return RedirectToAction("Login");
            }

            return RedirectToAction("Top");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return PartialView("Register");
        }

        [HttpPost]
        public IActionResult Register(RegisterDto inDto)
        {
            Boolean doesEmailExist = validateEmail(inDto);

            if(doesEmailExist)
            {
                TempData["EmailError"] = "Error: Email is already in use!";

                return RedirectToAction("Register");
            }


            Boolean comparePassword = validatePassword(inDto);

            if(!comparePassword)
            {

                TempData["PasswordError"] = "Error: Password does not match!";

                return RedirectToAction("Register");
            }
          
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(inDto.Password);

            inDto.Password = hashedPassword;

            UserModel newUser = new UserModel();

            newUser.Email = inDto.Email;

            newUser.FirstName = inDto.FirstName;

            newUser.LastName = inDto.LastName;

            newUser.Password = hashedPassword;

            _dbHelper.User.Add(newUser);

            _dbHelper.SaveChanges();

            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Top() 
        {

            return PartialView("Top");
        }

        public Boolean validatePassword(RegisterDto inDto)
        {

            if (inDto.Password != null && inDto.Password.Equals(inDto.ConPassword))
            {
                return true;
            }
            return false;
        }

        public Boolean validateEmail(RegisterDto inDto)
        {

            if(inDto.Email == null)
            {
                return true;
            }

            UserModel user = _dbHelper.GetUserByEmail(inDto.Email);

            if(user != null)
            {
                return true;
            }

            return false;
        }

        public Boolean validateLogin(LoginDto inDto)
        {

            UserModel user = _dbHelper.GetUserByEmail(inDto.Email);

            if(user == null || !BCrypt.Net.BCrypt.Verify(inDto.Password, user.Password))
            {
                return false;
            }

            return true;
        }

       
    }
}
