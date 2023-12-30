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

        public static List<Expense> GetExpenses(List<Expense>? Expenses){
            string dataFile = "/home/g/Documents/dotnet/ExpenseTracker/Models/data.txt";
            FileStream fs = new(dataFile, FileMode.Open,FileAccess.Read);
            StreamReader sr = new(fs);
            var nextLine = "";

            var expenses = new List<Expense>();
            while((nextLine=sr.ReadLine())!=null){
                var datas = nextLine.Split("   ");
                if(datas.Length==3){
                 Expense expense = new(){
                    ID=Convert.ToInt32(datas[0]),
                    Amount=datas[1],
                    Description=datas[2]
                 };
                 expenses.Add(expense);
                }
            }
            sr.Close();
            fs.Close();
            return Expenses?.Count>0?Expenses:expenses;
        }

        public static  void AddExpense(Expense expense){
             try{
                // pass absulte path of your file 
                string dataFile = "/home/g/Documents/dotnet/ExpenseTracker/Models/data.txt";
                FileStream fs = new(dataFile,FileMode.Append,FileAccess.Write);
                StreamWriter sr = new(fs);
                var expenses = GetExpenses(null);
                expense.ID=expenses.Count+1;
                string stringifedExpense = "\n"+expense.ID +
                "   "
                +expense.Amount
                +"   "
                +expense.Description;
                sr.WriteLine(stringifedExpense);
                sr.Close();
                fs.Close();
             }catch(Exception exception){
                Console.WriteLine(exception.Message);
             }
        }

        public static void UpdateExpense(Expense expense,int ID){
            var expenses = GetExpenses(null);
         var expenseTobeUpdated = expenses.Where(expense=>expense.ID==ID).ToArray()[0];
        }
      
        public static void UpdateData(List<Expense> expenses){
           try{
                // pass absulte path of your file 
                string dataFile = "/home/g/Documents/dotnet/ExpenseTracker/Models/data.txt";
                FileStream fs = new(dataFile,FileMode.Create,FileAccess.Write);
                StreamWriter sr = new(fs);

                foreach(Expense expense in expenses){
                string stringifedExpense = $"\n {expense.ID}   {expense.Amount}   {expense.Description}";
                  sr.WriteLine(stringifedExpense);
                }

                sr.Close();
                fs.Close();
             }catch(Exception exception){
                Console.WriteLine(exception.Message);
             }
        }

        public static void DeleteExpense(int ID){
         var expenses = GetExpenses(null);
         var remainingExpenses = expenses.Where(expense=>expense.ID!=ID).ToList();
         UpdateData(remainingExpenses);
        }
        
    }
}