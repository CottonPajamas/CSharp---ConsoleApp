using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//--------------------------------------------   Convert the first letter of every word to uppercase   ------------------------------------------------//
namespace Collections_Mini_projects
{
    class Program2a
    {
        static void Main(string[] args)
        {
            string input = "institute of systems science";
            string[] input_split = input.Split(' ');
            //Splitting the sentence into words
            for (int i = 0; i <= input_split.Length - 1; i++) //Think delimeter by space :D
            {
                // convert to char array of the string
                char[] letters = input_split[i].ToCharArray();
                // upper case the first char
                letters[0] = char.ToUpper(letters[0]);
                // return the array made of the new char array
                string r = new string(letters);
                input_split[i] = r;
                //If you wanna check
                //Console.WriteLine(input_split[i]);
            }
            //Combining the words back into sentence
            for (int j = 0; j < input_split.Length; j++)
            {
                Console.Write(input_split[j]);
                if (j < input_split.Length - 1)
                {
                    Console.Write(" ");
                }
            }
            Console.Write("\n");
        }
    }
}







//-------------------------------------------   Sorting   ------------------------------------------------//

//Great cos we take the swap function one step further in that we are swapping
//both arrays together based on the value (whether its bigger/smaller) of one array.
namespace Collections_Mini_projects
{
    class Program2b
    {
        static void Main(string[] args)
        {
            string[] StudentName = new string[5] { "John", "Venkat", "Mary", "Victor", "Betty" };
            int[] marks = new int[5] { 63, 29, 75, 82, 55 };

            for (int a = 0; a < marks.Length - 1; a++) //--We minus 1 cos com counts from zero
            {
                for (int b = a + 1; b < marks.Length; b++)
                {
                    if (marks[a] < marks[b])
                    {
                        //We do the swap for the marks
                        int c = marks[a];
                        marks[a] = marks[b];
                        marks[b] = c;
                        //We do the swap for the names now
                        string n = StudentName[a];
                        StudentName[a] = StudentName[b];
                        StudentName[b] = n;
                    }
                }
            }
            // printing of array items that has been rearranged
            for (int i = 0; i < marks.Length; i++)
            {
                Console.WriteLine("\t{0}\t\t{1}", StudentName[i], marks[i]);
            }
        }
    }
}








//--------------------------------------------   Sorting   ------------------------------------------------//

//Swapping based on characters of the other array and not numbers.
//Basically, arrange alphabetically.
namespace Collections_Mini_projects
{
    class Program2c
    {
        static void Main(string[] args)
        {
            string[] StudentName = new string[5] { "John", "Venkat", "Mary", "Victor", "Betty" };
            int[] marks = new int[5] { 63, 29, 75, 82, 55 };

            for (int a = 0; a < StudentName.Length - 1; a++) //--We minus 1 cos com counts from zero
            {
                for (int b = a + 1; b < StudentName.Length; b++)
                {
                    string r = StudentName[a];
                    char student_intialA = r[0];
                    string q = StudentName[b];
                    char student_intialB = q[0];
                    if (student_intialA > student_intialB)
                    {
                        //We do the swap for the names now
                        string n = StudentName[a];
                        StudentName[a] = StudentName[b];
                        StudentName[b] = n;
                        //We do the swap for the marks
                        int c = marks[a];
                        marks[a] = marks[b];
                        marks[b] = c;
                    }
                }
            }
            // printing of array items that has been rearranged
            for (int i = 0; i < marks.Length; i++)
            {
                Console.WriteLine("\t{0}\t\t{1}", StudentName[i], marks[i]);
            }
        }
    }
}









//-------------------------------------------   Replacing char with another char   ------------------------------------------------//

//Will replace all of that specified char in your inputed phrase/sentence.
namespace Collections_Mini_projects
{
    class Program2d
    {
        static void Main(string[] args)
        {
            Console.Write("Please type anything: ");
            string s = Console.ReadLine().ToLower();
            Console.Write("Now type a letter: ");
            char c1 = Convert.ToChar(Console.ReadLine().ToLower());
            Console.Write("Another letter please: ");
            char c2 = Convert.ToChar(Console.ReadLine().ToLower());
            string new_word = Substitute(s, c1, c2);
            Console.Write(new_word);
        }

        static string Substitute(string s, char c1, char c2)
        {
            string output = "";
            if (s.Contains(c1)) //THIS ' .Contains() ' HERE IS DAMN IMPT!!!!
            {
                for (int i = 0; i <= s.Length - 1; i++)
                {
                    if (s[i] == c1)
                    {
                        output = s.Replace(c1.ToString(), c2.ToString());
                    } //MUST REMEMBER HOW TO CONVERT CHAR TO STRING
                }
            }
            else
            {
                output = "No such character in your string\n";
            }
            return output;
        }
    }
}







/*------------------------------------------------------    USING DELEGATION    ----------------------------------------------------------------------*/





//------------------------     Intro to delegation     --------------------------//
namespace Collections_Mini_projects
{
    class Program2e
    {
        /*Means that we are defining a new datatype called IntOps that represent a method that
        accepts an int and return an int*/
        delegate int IntOps(int n);            //Creation of delegation

        static void ApplyOperation(int[] arr, IntOps ops)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = ops(arr[i]);       //This line here takes a value from array 'arr', eg: 1,
            }  //and input it into ops. But because ops is a variable that has been defined/linked
        }      //to the delegation method, it essentially takes the '1', passes to method 'IntOps',
               //then passes it to 'Add10' to be added by 10, ie 'x + 10', and finally send back as
               //the new variable for arr[0]. Effectively replacing 1 with a new value of 11.


        static void Main(string[] args)   //Main method
        {
            //Create an array
            int[] A = new int[] { 1, 2, 3 };

            //MUST UNDS HOW THEY create a variable and ASSIGNING IT TO THE DELEGATION METHOD!!!!!!!!!
            IntOps myOp = Add10;    //Just use it as tho it is a data type.
            //'Add10' here is another method. So they create a variable called..
            //'myOp' and call method 'Add10' to assign a math function, but it still has no value.

            //Console.WriteLine(myOp);      //try this, you will get nothing cos its still empty.
            PrintArray(A);
            ApplyOperation(A, myOp);    //Only here then you add a value to the math operation that 
            PrintArray(A);                  //'Add10' has assigned to 'myOp'. This is also where the 
            //method-ceptions occurs. Cos here Main() method will call upon 'ApplyOperation()' 
            //method to perform its calculation. But in addition to that, 'ApplyOperation()' calls on
            //to the IntOps method which then calls on to the 'Add10' method. Totally sweet amirite??? :D



            //Same thing, just with different mathematical functions
            myOp = Minus1;
            PrintArray(A);
            ApplyOperation(A, myOp);
            PrintArray(A);


            myOp = Multiply2;
            PrintArray(A);
            ApplyOperation(A, myOp);
            PrintArray(A);
        }
        //------ANSWER-------//
        /*       1       2       3
                 11      12      13
                 11      12      13
                 10      11      12
                 10      11      12
                 20      22      24       */


        //These four methods, each creates a new value for the variable myOp 
        static int Add10(int x)
        {
            return x + 10;
        }

        static int Minus1(int x)
        {
            return x - 1;
        }
        static int Multiply2(int x)
        {
            return 2 * x;
        }

        static double Sqrt(int x)
        {
            return Math.Sqrt(x);
        }



        //This is just a method to print values on the console
        static void PrintArray(int[] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write(A[i] + "\t");
            }
            Console.WriteLine();
        }
    }
}









//------------------------     Multi assignations     --------------------------//

//We use delegation to calculate an integer here as well, but this time we input the delegated method into a delegation array!!!
namespace Collections_Mini_projects
{
    class Program2f
    {
        delegate int IntOps(int n);   //Creation of delegation

        static void ApplyOperation(int[] arr, IntOps ops)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = ops(arr[i]);   //Same as before
            }
        }

        //This is where the difference lies compared to the previous one
        static void Main()
        {
            int[] A = new int[] { 1, 2, 3 };

            //Below lies the code to assign the delegation method!!!
            IntOps[] operations = new IntOps[] { Add10, Minus1, Multiply2 };
            //Here, we essentially link three different methods within the 'operations' array. 
            //Basically instead of actual values, we put methods.
            //So if the particulat position is called, the respective method will be activated.


            for (int i = 0; i < operations.Length; i++)
            {
                //Here we create another variable using the delegation method
                IntOps myOp = operations[i];
                PrintArray(A);
                ApplyOperation(A, myOp);
                PrintArray(A);
            }
        }//Here's the logic. So when i=0, it refers to the 0 position within the operations 
         //array. This meant the 'Add10' method. Then when 'ApplyOperation' is called, 
         //it will take array A with all of its values, namely 1, 2 and 3, and the 'Add10'
         //method to be calculated.


        static int Add10(int x)
        {
            return x + 10;
        }

        static int Multiply2(int x)
        {
            return 2 * x;
        }

        static int Minus1(int x)
        {
            return x - 1;
        }

        static void PrintArray(int[] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write(A[i] + "\t");
            }
            Console.WriteLine();
        }
    }
}








//------------------------     Another delegation example     --------------------------//
namespace Collections_Mini_projects
{
    class Program2g
    {
        delegate double DoubleOps(double x); //Note that a delegation method ends with ';'

        static void Main()
        {
            double[] arr = new double[] { 2, 6, 8, 94, 54, 11, 47, 56 };

            //New arrays
            double[] new_arr1 = ProcessArray(arr, SquareRoot);//So the process method will take
            PrintArray(new_arr1);                      //the original array and the sqrt method
            //Here, you dont need to call for the delegate method explicitly, cos its already
            //infused with the process method as seen below.

            double[] new_arr2 = ProcessArray(arr, Square);
            PrintArray(new_arr2);
        }



        //Method that will be called when delegation is activated
        static double[] ProcessArray(double[] arr, DoubleOps ops)  //By calling the delegate 
        {      //method, even tho in Main() it states the 'SquareRoot' method, any value taken
               //taken in the for loop will be passed to the delegate method and only then 
               //to the 'SquareRoot' method.

            //You cannot just put 'SquareRoot' method in Main() and then here write 
            //'double ops' instead of 'DoubleOps ops' cos by right in the argument,
            //you can only write variables within the Main() method. But if you wanna
            //call a method to perform a function, then a way to bypass the restriction
            //is to use delegation, and use it as a data type when processing and calling
            //the desired method which in this case is the square root method.


            double[] newArray = new double[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                newArray[i] = ops(arr[i]);
            }    //REMEMBER HOW ITS WRITTEN TO BE CALLED!!!

            return newArray;
        }


        //Method to perform square root
        static double Square(double input)
        {
            return (input * input);
        }

        //Method to perform square
        static double SquareRoot(double input)
        {
            return Math.Sqrt(input);
        }

        //Method to print out an array
        static void PrintArray(double[] array)
        {
            Console.Write("[ ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0:0.##}, ", array[i]);
            }
            Console.WriteLine("\b\b ]\n");
        }
    }
}


