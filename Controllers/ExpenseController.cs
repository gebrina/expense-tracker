using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.Models;

namespace ExpenseTracker.Controllers{
    public class ExpenseController:Controller{
        public IActionResult Index(){
         var expenses = Expense.GetExpenses();
            return View(expenses);
        }
          
        [HttpPost]
        public IActionResult Index(Expense expense){
            Expense.AddExpense(expense);
            var expenses = Expense.GetExpenses();
            return View(expenses);
        }
    }
}