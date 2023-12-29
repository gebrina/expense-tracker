using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.Models;

namespace ExpenseTracker.Controllers{
    public class ExpenseController:Controller{
        public IActionResult Index(){
         var expenses = Expense.GetExpenses();
            return View(expenses);
        }
    }
}