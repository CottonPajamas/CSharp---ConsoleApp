using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//-------------------------------------------   Matrix mulitplication   ------------------------------------------------//

//Understand how to read and modify a 2D matrix with multiple rows and columns
//Understand how to check for the dimensions of the array / matrix.
//Unds how we convert the string into a string array
//Unds how we put back in all our values from a single array into a 2D array.
namespace Collections_Mini_projects
{
    class Program3a
    {
        static void Main(string[] args)
        {
            int[,] firstArray = new int[5, 5] { { 4,5,49,4,8}, { 3,13,4,9,12 }, { 3,3,8,7,24 },
                { 2,7,5,9,3}, { 2,3,4,23,2 } };
            int[,] secondArray = new int[5, 7] { { 3,7,8,3,2,2,8 }, { 8,2,7,2,2,12,1 },
                { 29,2,7,1,9,29,22}, { 2,9,4,7,3,31,1 }, { 7,1,4,1,7,9,3 } };

            //Understand how a 2D array asssigns all its numbers.
            //Shortcut: In fristArray, its a 2 by 3 matrix which looks like this,
            //                         | 35  82  33 |  Its always row by columns!!!
            //  Try playing around,    | 67  45  44 |
            //Console.WriteLine(secondArray[0,2]);


            //Perform our check
            bool check = checkMatrix(firstArray, secondArray);


            if (check == true)
            {
                int[,] result = matrixMultiply(firstArray, secondArray);

                //Printing out our matrix
                printArray(result);
            }
            else
            {
                Console.WriteLine("Sorry but the two matrices are not able to be multiplied.\n"
                    + "Please make sure that the number of columns in Matrix A is equal to the"
                    + " number of rows in Matrix B.");
            }
            //Perform our calculation



        }

        //Method to check if you can perform matrix multiplication
        static bool checkMatrix(int[,] a, int[,] b)
        {
            //Check for the type of matrix,    should get 3 X 2 matrix
            //Console.Write("{0} X {1}", no_rows_A, no_cols_A);

            int no_cols_A = a.GetLength(1);
            int no_rows_B = b.GetLength(0);
            //We just need two of them. Later then we need all four.

            if (no_cols_A == no_rows_B) { return true; }
            else { return false; }
        }

        //Method to perform our matrix calculation
        static int[,] matrixMultiply(int[,] a, int[,] b)
        {
            int no_rows_A = a.GetLength(0);
            int no_cols_A = a.GetLength(1);
            int no_rows_B = b.GetLength(0);
            int no_cols_B = b.GetLength(1);
            int result = 0;
            int count = 0;

            string output = "";

            int[,] new_matrix = new int[no_rows_A, no_cols_B];

            for (int i = 0; i <= no_rows_A - 1; i++)
            {
                //Must reset both the result count.
                result = 0;
                count = 0;

                for (int k = 0; k <= no_cols_B - 1; k++)
                {
                    //Must reset both the result count.
                    result = 0;
                    count = 0;

                    for (int j = 0; j <= no_cols_A - 1; j++)
                    {
                        result = result + (a[i, j] * b[j, k]);
                        count++;

                        if (count == no_cols_A)
                        {
                            output = output + Convert.ToString(result) + " ";
                        }
                    }
                }
            }

            //We convert our string into a string array
            string[] output_array = output.Split(' ');


            int position_count = 0;
            //Now we put back humpty dumpty back together again
            for (int i = 0; i <= new_matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j <= new_matrix.GetLength(1) - 1; j++)
                {
                    int c = int.Parse(output_array[position_count]);
                    new_matrix[i, j] = c;
                    position_count++;
                }
            }
            position_count = 0;


            //Console.WriteLine(output);
            return new_matrix;
        }



        //Method for printing out your array
        static void printArray(int[,] result)
        {
            Console.WriteLine("------------------------Matrix-----------------------------");

            for (int i = 0; i <= result.GetLength(0) - 1; i++)
            {
                Console.Write("   |\t");
                for (int j = 0; j <= result.GetLength(1) - 1; j++)
                {
                    Console.Write("{0}\t", result[i, j]);
                }
                Console.WriteLine("\b|\n");
            }
            
        }
    }
}








//-------------------------------------------   Multiple conditions   ------------------------------------------------//

/*Conditions:
 1) Username has to start with 2 alphabets followed by 5 integers.
 2) Username has to be strictly 7 characters only.
 3) Password has to be at least 8 characters long.
 4) Password must contain a combination of upper and lower case characters as well as numbers. (At least one of each)
 5) Must be an email address entered and not some random string.
 */
namespace Collections_Mini_projects
{
    class Program3b
    {
        //Main method - By keeping the codes separate from the main(), we have the ability to easily expand this application in the future.
        static void Main(string[] args)
        {
            PromptUser();
        }

        //Prompt method
        private static void PromptUser()
        {
            //Attributes used to check if the conditions for each of the three are met
            bool checkUserName = false;
            bool checkPass = false;
            bool checkEmail = false;

            Console.WriteLine("The first two characters of your username must be integers and the remaining 5 must be letters.");

            do
            {
                Console.Write("Please enter your 7 character username: ");
                checkUserName = CheckUserName(Console.ReadLine());

                Console.Write("Please enter your password: ");
                checkPass = CheckPass(Console.ReadLine());

                Console.Write("Please enter email address: ");
                checkEmail = CheckEmail(Console.ReadLine());

                if (checkUserName == false || checkPass == false || checkEmail == false)
                {
                    Console.WriteLine("The details you have entered are incorrect. Please try again.\n\n");
                }


            } while (checkUserName == false || checkPass == false || checkEmail == false);

            Console.WriteLine("Congratulations, your application is successful.");
        }

        //Method to check the username inputted
        private static bool CheckUserName(string input)
        {
            int num = 0;

            //Must be 7 character long
            if (input.Count() == 7)
            {
                try
                {
                    for (int i = 2; i < 7; i++)
                    {
                        num = Convert.ToInt32(input[i]) / 1;
                    }

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else return false;
        }

        //Method to check the password inputted
        private static bool CheckPass(string input)
        {
            //This here are useful function used to check if any of the chars in the string is an upper case, lower case or a digit.
            if (input.Any(char.IsUpper) && input.Any(char.IsLower) && input.Any(char.IsDigit) && input.Count() > 7)
            {
                return true;
            }
            else return false;
        }

        //Method to check the email inputted
        private static bool CheckEmail(string input)
        {
            //Here, the best way to check if the inputted string is an email address is to check if it has the '@' symbol
            //in it, as well as having '.com' at end of the string.
            int numChar = input.Count();
            string dotCom = ".com";
            string r = input.Substring(numChar - 4, 4);
            r = r.ToLower();

            if (r == dotCom && input.Contains('@'))
            {
                return true;
            }
            else return false;
        }
    }
}

