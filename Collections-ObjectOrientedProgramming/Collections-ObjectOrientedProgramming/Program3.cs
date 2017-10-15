using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//-----------------------------------------   Using polymorphism with interfaces   ------------------------------------------------//
//Another eg.

//Our product class to create objects for each product.
namespace eSupermarket
{
    public class Product
    {
        private string productName;
        private double productPrice;
        private double productQuantity;

        public Product(string a, double b, double c)
        {
            this.productName = a;
            this.productPrice = b;
            this.productQuantity = c;
        }
        public void Show()
        {
            Console.WriteLine("{0}\t\t{1:c}\t\t{2}", PdtName, PdtPrice, PdtQuantity);
        }

        public string PdtName { get { return productName; } }
        public double PdtPrice { get { return productPrice; } }
        public double PdtQuantity { get { return productQuantity; } }
    }
}



//Our customer classes
namespace eSupermarket
{
    //Interface
    public interface ICustTemplate
    {
        void ShowReceipt();
    }

    //Parent class
    public class Customers
    {
        private int orderID;
        private double totalReceipts;
        private string paymentMethod;
        private ArrayList productList;

        //Constructors
        public Customers(int orderID, string paymentMethod)
        {
            this.orderID = orderID;
            this.paymentMethod = paymentMethod;
            productList = new ArrayList();
            Shopping.database.Add(this);
        }
        public virtual void AddItem(string a, double b, double c)
        {
            Product pdt = new Product(a, b, c);
            productList.Add(pdt);
        }
        public virtual double CalculateProductTotal()
        {
            for (int i = 0; i < productList.Count; i++)
            {
                Product j = (Product)productList[i];
                TotalReceipts = TotalReceipts + (j.PdtPrice * j.PdtQuantity);
            }

            return TotalReceipts;
        }

        public void ShowPdtList()
        {
            for (int i = 0; i < productList.Count; i++)
            {
                Product j = (Product)productList[i];
                j.Show();
            }
        }

        public int OrderId { get { return orderID; } }
        public double TotalReceipts { get { return totalReceipts; } set { totalReceipts = value; } }
        public string PaymentMethod { get { return paymentMethod; } }
        public ArrayList ProductList { get { return productList; } }
    }

    //Child class
    public class RegularCustomer : Customers, ICustTemplate
    {
        //Constructor
        public RegularCustomer(int orderID, string paymentMethod) : base(orderID, paymentMethod)
        { }

        //Methods
        public void ShowReceipt()
        {
            Console.WriteLine("OrderID: " + OrderId + "\t\t" + "Payment Method: " + PaymentMethod);
            Console.WriteLine("\nProduct\t\tPrice\t\tQuantity");
            ShowPdtList();
            Console.WriteLine("\nTotal Bill: {0:c}\n\n\n", CalculateProductTotal());
        }
    }

    //Another child class
    public class LoyalCustomer : Customers, ICustTemplate
    {
        private int loyaltyPoints;
        private string customerName;
        private double discountGiven;
        public double TotalReceiptsB;

        public LoyalCustomer(int orderID, string paymentMethod, string name) : base(orderID, paymentMethod)
        {
            loyaltyPoints = 0;
            this.customerName = name;
            discountGiven = 0;
            TotalReceiptsB = 0;
        }


        //Methods
        public override double CalculateProductTotal()
        {
            for (int i = 0; i < ProductList.Count; i++)
            {
                Product j = (Product)ProductList[i];
                TotalReceipts = TotalReceipts + (j.PdtPrice * j.PdtQuantity);
            }

            if (TotalReceipts > 100)   //If more than $100, members have 15% discount
            {
                DiscountGiven = TotalReceipts * 0.15;
                TotalReceiptsB = TotalReceipts - DiscountGiven;
                return TotalReceiptsB;
            }
            else { return TotalReceipts; }
        }
        public int CalculateLoyaltyPoints()
        {
            if (TotalReceipts > 100) { LoyaltyPoints += 100; }
            if (TotalReceipts > 200) { LoyaltyPoints += 100; }
            if (TotalReceipts > 300) { LoyaltyPoints += 100; }

            return LoyaltyPoints;
        }
        public void ShowReceipt()
        {
            Console.WriteLine("Member Name: " + CustomerName);
            Console.WriteLine("OrderID: " + OrderId + "\t\t" + "Payment Method: " + PaymentMethod);
            Console.WriteLine("\nProduct\t\tPrice\t\tQuantity");
            ShowPdtList();
            CalculateProductTotal();
            Console.WriteLine("\nSubtotal: {0:c}", TotalReceipts);
            Console.WriteLine("Discount Received: {0:c}", DiscountGiven);
            Console.WriteLine("Total Bill: {0:c}", TotalReceiptsB);
            CalculateLoyaltyPoints();
            Console.WriteLine("Total Loyalty Points: " + LoyaltyPoints);
        }


        public string CustomerName { get { return customerName; } }
        public int LoyaltyPoints { get { return loyaltyPoints; } set { loyaltyPoints = value; } }
        public double DiscountGiven { get { return discountGiven; } set { discountGiven = value; } }
    }
}



namespace eSupermarket
{
    public class Shopping
    {
        static void Main()
        {
            //Adding our reg customers
            RegularCustomer ss = new RegularCustomer(234561, "VISA");
            ss.AddItem("apples", 5, 10);
            ss.AddItem("pear", 50, 1);
            ss.AddItem("coke", 6, 8);
            ss.ShowReceipt();

            //Adding our loyal customers
            LoyalCustomer hh = new LoyalCustomer(038271, "MasterCard", "Denzel Washington");
            hh.AddItem("cider", 6, 15);
            hh.AddItem("shampoo", 3, 10);
            hh.AddItem("salt", 10, 20);
            hh.ShowReceipt();

            //Checking the coy's customers database
            Show(database);

        }

        public static ArrayList database = new ArrayList();
        public static void Show(ArrayList a)  //Includes both loyal and reg customers
        {
            for (int i = 0; i < a.Count; i++)
            {
                Console.WriteLine(a[i]);
            }
        }
    }
}
