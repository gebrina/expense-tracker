using System.Linq;
using System.Collections.Generic;

namespace ExpenseTracker.Models{
    public class Expense{
        public string Description {get;set;}="";
        public double Amount {get;set;}
        public int ID {get;set;}

        public List<Expense> Expenses = [];

        public List<Expense> GetExpenses(){
            return Expenses;
        }

        public void AddExpense(Expense expense){
            Expenses.Add(expense);
        }

        public void UpdateExpense(Expense expense,int ID){
         var expenseTobeUpdated = Expenses.Where(expense=>expense.ID==ID).ToArray()[0];
         
        }
      
        public void DeleteExpense(int ID){
         var expenseTobeDeleted = Expenses.Where(expense=>expense.ID==ID);
        }
        
    }
}