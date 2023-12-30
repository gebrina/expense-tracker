using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models{
    public class Expense{
        [Key]
        public int ID {get;set;}

        [Required(ErrorMessage ="Please enter the description.")]
        public string Description {get;set;}="";

        [Required(ErrorMessage ="Please enter the amount.")]
        [RegularExpression(@"^[0-9]+$",ErrorMessage ="You must enter amount in numeric format.")]
        [Range(1,long.MaxValue,ErrorMessage ="Amount must be greater than 0")]
        public string Amount {get;set;} = string.Empty;
        public static List<Expense> Expenses =>[];

        public static List<Expense> GetExpenses(){
            return Expenses;
        }

        public static  void AddExpense(Expense expense){
             try{
                // pass absulte path of your file 

                string expensesFile = "/home/g/Documents/dotnet/ExpenseTracker/Models/data.txt";
                FileStream fs = new(expensesFile,FileMode.Append,FileAccess.Write);
                StreamWriter sr = new(fs);
                expense.ID = Expenses.Count + 1;
                string stringifedExpense = "\n"+expense.ID +
                "                             "
                +expense.Amount
                +"                            "
                +expense.Description;
                sr.WriteLine(stringifedExpense);
                sr.Close();
                fs.Close();
                Console.WriteLine("text writen"+ stringifedExpense);
             }catch(Exception exception){
                Console.WriteLine(exception.Message);
             }
        }

        public static void UpdateExpense(Expense expense,int ID){
         var expenseTobeUpdated = Expenses.Where(expense=>expense.ID==ID).ToArray()[0];
        }
      
        public void DeleteExpense(int ID){
         var expenseTobeDeleted = Expenses.Where(expense=>expense.ID==ID);
        }
        
    }
}