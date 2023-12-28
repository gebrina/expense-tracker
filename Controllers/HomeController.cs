using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.Models;

namespace ExpenseTracker.Controllers{
    public class HomeController:Controller{
        public IActionResult Index(){
            return View();
        }
    }
}