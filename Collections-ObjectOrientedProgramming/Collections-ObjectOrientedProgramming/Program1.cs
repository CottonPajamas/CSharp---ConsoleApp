using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//-----------------------------------------   Single class (Basic)   ------------------------------------------------//


//Please note the return datatype for methods and properties!!!
//Since we are dealing with 'confidential info' the methods must be void so the user is unable
//to access it. All your attributes must also be private!!! You can only call it when you use the
//respective properties.
namespace Collections_ObjectOrientedProgramming
{
    public class Account1
    {
        //Attributes
        private string acc_Number, acc_Name;
        private double balance;             //Need put private cos confidential info

        //Constructor
        public Account1(string a, string b, double x)
        {
            acc_Number = a;
            acc_Name = b;
            balance = x;
        }
        public Account1() : this("000-000-000", "NONAME", 0)
        {
            // default values if none supplied
        }

        //Methods
        public string Show()
        {
            string m = String.Format
                         ("[Account:accountNumber={0},accountHolder={1},balance={2}]",
                          acc_Number, acc_Name, balance);
            return m;
        }
        public void Withdraw(double x)
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

        public void Deposit(double x)
        {
            this.balance = balance + x;
            Console.WriteLine("Deposit was a success.");
        }
        public void TransferTo(double x, Account1 b)
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


        //Properties
        public string AccountNumber
        {
            get { return acc_Number; }
        }        //No need set cos we wont change bank number lol

        public string AccountName
        {
            get { return acc_Name; }
            set { acc_Name = value; }
            //account holder name might change for various reasons such as death
        }

        public double Balance
        {
            get { return balance; }
        }
    }


    class BankTest1
    {
        static void Main(string[] args)
        {
            Account1 a = new Account1("001-001-001", "Tan Ah Kow", 2000);
            Account1 b = new Account1("001-001-002", "Kim Keng Lee", 5000);
            Console.WriteLine(a.Show());
            Console.WriteLine(b.Show());
            a.Deposit(100);
            Console.WriteLine(a.Show());
            a.Withdraw(200);
            Console.WriteLine(a.Show());
            a.TransferTo(300, b);
            Console.WriteLine(a.Show());
            Console.WriteLine(b.Show());
        }
    }
}







//-----------------------------------------   Multiple classes (Advance)   ------------------------------------------------//

namespace Collections_ObjectOrientedProgramming
{
    public class Customer2
    {
        //Attributes   -   Put privates cos its confidential
        private string acc_Name, address, passportNo;
        private DateTime dateOfBirth;    //DateTime is treated like an object???

        //Constructor -- UNDERSTAND HOW TO DO THIS!! IMPT!!! MOST COMPLEX CONSTRUCTOR!!!
        //  [The proper constructor will be invoked depending on the parameters or lack thereof]
        public Customer2(string name, string address, string passport) //If parameters are given
        {                                                               //except for dateofbirth.
            this.acc_Name = name;
            this.address = address;
            this.passportNo = passport;
            //'this' here points to the class' attributes and not the local variables created 
            //in the arguments. Very useful when both are the same like address. If not the same
            //then its optional to use.
        }
        public Customer2(string name, string address, string passport, DateTime dob)
            : this(name, address, passport)                         //If ALL paramters are given,
        {                                                                 //including dateofbirth.
            this.dateOfBirth = dob;
        }
        public Customer2(string name, string address, string passport, int age)
            : this(name, address, passport)                         //If ALL paramters are given,
        {                                   //but instead of dateofbirth, user inputs age instead.
            this.dateOfBirth = new DateTime(DateTime.Now.Year - age, 1, 1);
        }
        public Customer2()                                           //If no parameters are given.
            : this("NoName", "NoAddress", "NoPassport", new DateTime(1980, 1, 1)) { }


        //Method
        //We only have one method here to be used to call all the properties of the object
        public string Show()
        {
            string m = String.Format
                 ("[Customer:name={0},address={1},passport={2},age={3}]",
                          Acc_Name, Address, PassportNo, Age);
            //PLEASE NOTE: Our show here is referring to the properties and NOT the 
            //instance variable. It would defeat the purposed of privacy if youre
            //accessing it directly. >.>
            return (m);
        }

        //Properties
        //Please remember to do properties for every single attributes that you have
        public string Acc_Name
        {
            get
            {
                return acc_Name;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        public string PassportNo
        {
            get
            {
                return passportNo;
            }
            set
            {
                passportNo = value;
            }
        }

        //Useful cos learn how to calculate age!!!
        public int Age
        {
            get
            {
                //If you want to find todays date and time at this moment
                //use DateTime.Now   :D

                int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
                int dob = int.Parse(dateOfBirth.ToString("yyyyMMdd"));
                int age = (now - dob) / 10000;
                return age;
            }
        }

    }

    class BankTest2
    {
        static void Main(string[] args)
        {
            Customer2 y = new Customer2("Tan Ah Kow", "20, Seaside Road", "XXX20", new DateTime(1989, 10, 11));
            Customer2 z = new Customer2("Kim Lee Keng", "2, Rich View", "XXX9F", new DateTime(1993, 4, 25));
            Account2 a = new Account2("001-001-001", y, 2000);
            Account2 b = new Account2("001-001-002", z, 5000);
            Console.WriteLine(a.Show());
            Console.WriteLine(b.Show());
            a.Deposit(100);
            Console.WriteLine(a.Show());
            a.Withdraw(200);
            Console.WriteLine(a.Show());
            a.TransferTo(300, b);
            Console.WriteLine(a.Show());
            Console.WriteLine(b.Show());

            int n1 = y.Age;
            Console.WriteLine(n1);
            int n2 = z.Age;
            Console.WriteLine(n2);
        }
    }

    public class Account2
    {
        //Attributes
        private string acc_Number;
        private string acc_Name;
        private double balance;             //Need to put private cos confidential info. REMEMBER ENCAPSULATION!!!

        //Constructor
        public Account2(string a, Customer2 b, double x)     //When theres parameters.
        {
            acc_Number = a;
            acc_Name = b.Acc_Name;
            balance = x;
        }
        public Account2()
            : this("000-000-000", new Customer2(), 0) { }     //When theres no parameters.
        //This constructor here is just another constructor put in place just in case you did not
        //declare any parameters when creating the object. 'this' here refers to this current
        //object being created. Its a more professional way to write a constructor when no 
        //parameters is given. SO REMEMBER IT!!!!!!!!!!!!!

        //Methods
        public string Show()
        {
            string m = String.Format
                         ("[Account:accountNumber={0},accountHolder={1},balance={2}]",
                          acc_Number, acc_Name, balance);
            return (m);
        }
        public void Withdraw(double x)
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

        public void Deposit(double x)
        {
            this.balance = balance + x;
            Console.WriteLine("Deposit was a success.");
        }
        public void TransferTo(double x, Account2 b)
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


        //Properties
        public string AccountNumber
        {
            get { return acc_Number; }
        }        //No need set cos we wont change bank number lol

        public string AccountName
        {
            get { return acc_Name; }
            set { acc_Name = value; }
            //account holder name might change for various reasons such as death
        }

        public double Balance
        {
            get { return balance; }
        }
    }

}




