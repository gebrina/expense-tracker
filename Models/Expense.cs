using System.Linq;
using System.Collections.Generic;

namespace ExpenseTracker.Models{
    public class Expense{
        public string Description {get;set;}="";
        public double Amount {get;set;}
        public int ID {get;set;}

        public List<Expense> Expenses = [];

        public static List<Expense> GetExpenses(){
            Expense forMobile = new(){ID=1,Description="Because I have to buy mobile phone.",Amount=200};
            Expense forComputer = new(){ID=2,Description="Because I have to buy Computer",Amount=800};
            Expense forSofa = new(){ID=3,Description="Because I have to buy sofa",Amount=400};
            Expense forTv = new(){ID=4,Description="Because I have to buy Tv",Amount=800};
            //return Expenses;
            return [forComputer,forMobile,forSofa,forTv];
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