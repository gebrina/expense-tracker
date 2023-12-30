using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.Models;

namespace ExpenseTracker.Controllers{
    public class ExpenseController:Controller{

        [Route("/Expense")]
        public IActionResult Index(){
         var expenses = Expense.GetExpenses(null);         
            return View(expenses);
        }
        
        [HttpGet]
        [Route("/Expense/Index/{ID}")]
        public IActionResult Index(string ID){
         Expense.DeleteExpense(Convert.ToInt32(ID));
         return Redirect("/Expense");
        }
          
        [HttpPost]
        [Route("Expense")]
        public IActionResult Index(Expense expense){
            Expense.AddExpense(expense);
            var expenses = Expense.GetExpenses(null);
            return View(expenses);
        }
    }
}