using BusinessLogicLayer;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UserTest.Models;

namespace UserTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<UserModel> userModels = new List<UserModel>();
            UserContainer uc = new UserContainer(new UserDAL());
            List<User> users = uc.GetAllUsers();

            foreach (User user in users)
            {
                userModels.Add(new UserModel() { Name = user.Name, Password = user.Password});
            }

            return View(userModels);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public void ShowList()
        {
            UserContainer uc = new UserContainer(new UserDAL());

            List<User> users = uc.GetAllUsers();

        }
    }
}