using System;
using System.Collections;             //Add this so you can use ArrayList().
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//-----------------------------------------   BACK REFERENCE (Bonus)   ------------------------------------------------//
namespace Collections_ObjectOrientedProgramming
{
    class BackReferencePractice
    {
        static void Main()
        {
            Driver m = new Driver("Michael");
            m.Buy("Ferrari");


            //MUST UNDERSTAND!!!!!!
            Console.WriteLine(m.Name);              //out: Michael
            Console.WriteLine(m.Mycar);             //out: Day10.Car [The object car basically]
            Console.WriteLine(m.Mycar.TheOwner);    //out: Day10.Driver [Object driver]
            Console.WriteLine(m.Mycar.Brand);       //out: Ferrari

            Console.WriteLine(m.Mycar.TheOwner.Name);  //out: Michael
            Console.WriteLine(m.Mycar.TheOwner.Mycar.TheOwner.Mycar.TheOwner.Mycar.TheOwner.
                Mycar.Brand);           //out: Ferrari  
                                        //You are essentially making a new object till perpetuity.
                                        //Its nonsensical and you should not apply it in your work/ 
                                        //But its still useful in understanding the concepts behind back-reference.
        }
    }

    public class Car
    {
        Driver theowner;    //Create an object within the object.
        string brand;                    //This object-ception is the essence of back reference!

        public Car(string brand) { this.brand = brand; }

        public void SetOwner(Driver d)
        {
            this.theowner = d;     //This sets the parameter to the instance variable.
        }
        public string Brand { get { return brand; } }
        public Driver TheOwner { get { return theowner; } }
    }


    public class Driver
    {
        private Car mycar;    //Creaing an opposite of the object
        string name;

        //Constructor
        public Driver(string name) { this.name = name; }
        //Method
        public void Buy(string x)
        {
            mycar = new Car(x);
            mycar.SetOwner(this);
        }
        //Properties
        public string Name { get { return name; } }
        public Car Mycar { get { return mycar; } }
    }
}







//-----------------------------------------   Using virtual & override   ------------------------------------------------//

//This is an evolution from the bank example in Program1.
namespace Collections_ObjectOrientedProgramming
{
    //We copy the Customer and Account class from Program1.
    //All the same, just a bit of changes to the name.
    public class Customer3
    {
        //Attributes
        private string acc_Name, address, passportNo;
        private DateTime dateOfBirth;    //DateTime is treated like an object. Its a system default. Look up in MSDN.

        //Constructor
        public Customer3(string a, string b, string c, DateTime d)
        {
            acc_Name = a;
            address = b;
            passportNo = c;
            dateOfBirth = d;
        }

        //Methods
        public int GetAge()  //Useful cos learn how to calculate age
        {
            //If you want to find todays date and time at this moment
            //use DateTime.Now   :D

            int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            int dob = int.Parse(dateOfBirth.ToString("yyyyMMdd"));
            int age = (now - dob) / 10000;
            return age;
        }
        public string Show()
        {
            string m = String.Format
                 ("[Customer:name={0},address={1},passport={2},age={3}]",
                          acc_Name, address, passportNo, GetAge());
            return (m);
        }

        //Properties
        public string Acc_Name
        {
            get { return acc_Name; }
            set { acc_Name = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string PassportNo
        {
            get { return passportNo; }
            set { passportNo = value; }
        }
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

    }


    public class Account3
    {
        //Attributes
        private string acc_Number;
        private string acc_Name;
        private double balance;             //Need put private cos confidential info
        private double interestRate;    //Not best to put this here as the object variable
                                        //as it implies all account have same interestRate
                                        //Constructor
        public Account3()        //If no parameters is set
        {
            acc_Number = "Nil";
            acc_Name = "Nil";
            balance = 0;
            interestRate = 0;
        }
        public Account3(string a, Customer3 b, double x, double y = 0)    //If there are parameters
        {
            acc_Number = a;
            acc_Name = b.Acc_Name;
            balance = x;
            interestRate = y;
        }

        //Methods
        //The only diff now is that we add virtual to withdraw and transfer cos
        //in overdraft account, this method will no longer hold since you can withdraw more 
        //than what you have in your account.
        public string Show()
        {
            string m = String.Format(
                         "[Account:accountNumber={0},accountHolder={1},balance={2}]",
                         acc_Number, acc_Name, balance);
            return (m);
        }
        public virtual void Withdraw(double x)
        {
            if (balance > 0)
            {
                if (balance > x)
                {
                    this.balance = balance - x;
                    Console.WriteLine("Withdrawal was a success.");
                }
                else
                {
                    Console.WriteLine("Error. Your balance is less than the withdrawal amount");
                }
            }
            else { Console.WriteLine("ERROR: The balance inputed is below $0."); }
        } //Here we add the zero condition to simplify things, so only need override and change
          //this method if we are dealing with the overdraft account. Same for TransferTo.

        public void Deposit(double x)
        {
            this.balance = balance + x;
            Console.WriteLine("Deposit was a success.");
            noDeposits(x);
        }
        
        public static double totalDeposits = 0;
        public static double noDeposits(double x)
        {
            totalDeposits += x;
            return totalDeposits;
        }
        public static double totalInterestPaid = 0;
        public static double InterestPaid(double x)
        {
            totalInterestPaid += x;
            return totalInterestPaid;
        }
        public static double totalInterestEarned = 0;
        public static double InterestEarned(double x)
        {
            totalInterestEarned += x;
            return totalInterestEarned;
        }




        public virtual void TransferTo(double x, Account3 b)
        {
            if (balance > 0)
            {
                if (balance > x)
                {
                    //Deduct from A
                    this.balance = balance - x;

                    //Add to accnt B
                    b.Deposit(x);
                }
                else
                {
                    Console.WriteLine("Error. Your balance is less than the transfered amount");
                }
            }
            else { Console.WriteLine("ERROR: The balance inputed is below $0."); }
        }


        //Calculate and deposit interest
        //We add virtual cos it will be overridden in the 'child' classes
        public virtual void CalculateInterest()
        {
            if (balance > 0)
            {
                double annualInterest = balance * interestRate / 100;
                CreditInterest(annualInterest);
                InterestPaid(annualInterest);
            }
            else { Console.WriteLine("ERROR: Unable to compute."); }
        }
        public virtual void CreditInterest(double x)
        {
            if (balance > 0)
            {
                balance = balance + x;
                Console.WriteLine("Your interest of {0} has been deposited to your account.", x);
            }
            else { Console.WriteLine("ERROR: Unable to compute."); }
        }


        //Properties
        public string Acc_Number
        {
            get { return acc_Number; }
        }        //No need set cos we wont change bank number lol

        public string Acc_Name
        {
            get { return acc_Name; }
            set { acc_Name = value; }
            //account holder name might change for various reasons such as death
        }

        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public double InterestRate
        {
            get { return interestRate; }
            set { interestRate = value; }
        }

    }
}


//Main method
namespace Collections_ObjectOrientedProgramming
{
    public class BankTest3    //Main account here
    {
        //Play around with it.
        static void Main(string[] args)
        {
            Customer3 y = new Customer3("Tan Ah Kow", "20, Seaside Road", "XXX20", new DateTime(1989, 10, 11));
            Customer3 z = new Customer3("Kim Lee Keng", "2, Rich View", "XXX9F", new DateTime(1993, 4, 25));
            Account3 a = new Account3("001-001-001", y, 2000, 2.0);
            Account3 b = new Account3("001-001-002", z, 5000, 1.0);
            Console.WriteLine(a.Show());
            Console.WriteLine(b.Show());
            a.Deposit(100);
            Console.WriteLine(a.Show());
            a.Withdraw(200);
            Console.WriteLine(a.Show());
            a.TransferTo(300, b);
            Console.WriteLine(a.Show());
            Console.WriteLine(b.Show());

            int n1 = y.GetAge();
            Console.WriteLine(n1);
            int n2 = z.GetAge();
            Console.WriteLine(n2);

            Customer3 zy = new Customer3("Kim Lee Keng", "2, Rich View", "XXX9F", new DateTime(1993, 4, 25));
            Account3 c = new SavingsAccount3("001-001-002", zy, -1000);
            Account3 d = new CurrentAccount3("001-001-002", zy, -1000);
            Account3 e = new OverdraftAccount3("001-001-002", zy, -1000);

            c.CalculateInterest();
            d.CalculateInterest();
            e.CalculateInterest();
            string n = e.Acc_Name;
            Console.WriteLine(n);
            Console.WriteLine(e.Show());
        }
    }
}



//This here will be the where all the three 'child' classes will be created.
//We are not required to create new attributes for savings and current account.
//Only overdraft acount need to add new attributes and methods to take into a/c the 
//negative charges incurred.
namespace Collections_ObjectOrientedProgramming
{ 
    public class SavingsAccount3 : Account3
    {
        //Constructor
        public SavingsAccount3(string a, Customer3 b, double x, double y = 1.0) : base(a, b, x, y)
        {
            //Check if negative balance.
            if (x < 0)
            {
                Console.WriteLine("ERROR: The balance inputed is below $0.");
            }
        }
    }

    public class CurrentAccount3 : Account3
    {
        //Constructor
        public CurrentAccount3(string a, Customer3 b, double x, double y = 0.25) : base(a, b, x, y)
        {
            //Check if negative balance.
            if (x < 0)
            {
                Console.WriteLine("ERROR: The balance inputed is below $0.");
            }
        }
    }

    public class OverdraftAccount3 : Account3
    {
        //New attribute
        private double negativeInterestRate;

        public OverdraftAccount3(string a, Customer3 b, double x, double y = 0.25, double z = 6)
            : base(a, b, x, y)
        {
            negativeInterestRate = z;
        }

        //The 5 new methods for OverdraftAccount
        //The four below are overrides
        public override void Withdraw(double x)
        {
            Balance = Balance - x;
        }

        public override void TransferTo(double x, Account3 b)
        {
            //Deduct from account
            Balance = Balance - x;

            //Add to target account
            b.Deposit(x);
        }

        public override void CalculateInterest()
        {
            if (Balance >= 0)
            {
                double annualInterest = Balance * InterestRate / 100;
                CreditInterest(annualInterest);
            }
            else if (Balance < 0)
            {
                double annualInterest = (Balance * -1) * negativeInterestRate / 100;
                DebitInterest(annualInterest);
                InterestEarned(annualInterest);
            }
        }

        public override void CreditInterest(double x)
        {
            Balance = Balance + x;
            Console.WriteLine("Your interest of {0} has been credited to your account.", x);
        }

        //Below is the sole additional method
        public void DebitInterest(double x)
        {
            Balance = Balance - x;
            Console.WriteLine("Your interest of {0} has been debited to your account.", x);
        }


        //New property for the new attribute
        public double NegativeInterestRate
        {
            get { return negativeInterestRate; }
            set { negativeInterestRate = value; }
        }
    }
}