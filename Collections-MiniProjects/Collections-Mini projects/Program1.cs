using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//-----------------------------------------   Finding LCM of two numbers   ------------------------------------------------//
namespace Collections_Mini_projects
{
    class Program1a
    {
        static void Main(string[] args)
        {
            //Input
            Console.Write("Please a value for A: ");
            int inputa = Int32.Parse(Console.ReadLine());
            Console.Write("Please a value for B: ");
            int inputb = Int32.Parse(Console.ReadLine());
            //Other variables needed
            int residualNo = 1;
            bool hcf = false;
            int inputA = inputa;
            int inputB = inputb;
            while (hcf == false)
            {
                if (inputA > inputB)
                {
                    inputA = inputA - inputB;
                }
                if (inputB > inputA)
                {
                    inputB = inputB - inputA;
                }
                if (inputA == inputB)
                {
                    hcf = true;
                    residualNo = inputA;
                }
            }
            int LCM = (inputa * inputb) / residualNo;
            Console.WriteLine("The HCF is {0} and the LCM is {1}.", residualNo, LCM);

        }
    }
}







//------------------------------------------   Prime number check   ------------------------------------------------//
namespace Collections_Mini_projects
{
    class Program1b
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int input = int.Parse(Console.ReadLine());
            bool isPrime = true; // Move initialization to here
            for (int j = 2; j < input; j++) // you actually only need to check up to sqrt(i)
            {
                if (input % j == 0) // you don't need the first condition
                {
                    isPrime = false;
                    break;
                }
            }
            if (isPrime)
            {
                Console.WriteLine("It is a prime number.");
            }
            else
            {
                Console.WriteLine("It is not a prime number.");
            }
        }
    }
}





//---------------------------------------   Perfect number check   ------------------------------------------------//
namespace Collections_Mini_projects
{
    class Program1c
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int input = int.Parse(Console.ReadLine());
            int output = 0;
            for (int i = 2; i < input; i++) //adds from 0 to input
            {
                if (input % i == 0)
                {
                    output += i;
                }
            }
            //Check if perfect number
            if (input == output + 1)
            {
                Console.WriteLine("It is a perfect number.");
            }
            else
            {
                Console.WriteLine("It is not a perfect number.");
            }
        }
    }
}






//---------------------------------------   Number guessing game   ------------------------------------------------//
namespace Collections_Mini_projects
{
    class Program1d
    {
        static void Main(string[] args)
        {
            //Com pick a number btw 0-9
            Random r = new Random();
            int comNo = r.Next(0, 10);
            bool correctGuess = false;
            int noAttempts = 0;
            do
            {
                Console.Write("Guess a number between 0 and 9: ");
                int input = Int32.Parse(Console.ReadLine());
                if (input == comNo)
                {
                    correctGuess = true;
                }
                else
                {
                    noAttempts++;
                    Console.WriteLine("Try again.");
                }
            }
            while (correctGuess == false);
            if ((noAttempts > 0) && (noAttempts <= 2))
            {
                Console.WriteLine("Ahh you got me!");
                Console.WriteLine("It took you {0} tries!!! You're a wizard Harry!!!", noAttempts);
            }
            else if ((noAttempts > 2) && (noAttempts <= 5))
            {
                Console.WriteLine("Ahh you got me!");
                Console.WriteLine("It took you {0} tries. You are a good guess", noAttempts);
            }
            else
            {
                Console.WriteLine("It took you {0} tries. You are lousy >.>", noAttempts);
            }
        }
    }
}






//-------------------------------   Counting the number of vowels in a phrase   -------------------------------------------//
namespace Collections_Mini_projects
{
    class Program1e
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a phrase: ");
            string input = Console.ReadLine().ToLower();
            // convert to char array of the string
            char[] letters_input = input.ToCharArray();
            //vowels listk
            char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
            int noVowels = 0;
            int noA = 0, noE = 0, noI = 0, noO = 0, noU = 0;
            //To check if there is vowels inside the phrase
            for (int a = 0; a <= input.Length - 1; a++)
            {
                for (int b = 0; b <= vowels.Length - 1; b++)
                {
                    if (letters_input[a] == vowels[b])
                    {
                        noVowels += 1;
                        if (b == 0) { noA += 1; }
                        if (b == 1) { noE += 1; }
                        if (b == 2) { noI += 1; }
                        if (b == 3) { noO += 1; }
                        if (b == 4) { noU += 1; }
                    }
                }
            }
            Console.WriteLine("Total Vowels: {0}\nA: {1}\nE: {2}\nI: {3}\nO: {4}\nU: {5}",
            noVowels, noA, noE, noI, noO, noU);
        }
    }
}







//-----------------------------------   Palindrome check   -----------------------------------------//
namespace Collections_Mini_projects
{
    class Program1f
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a word: ");

            string input = Console.ReadLine().ToLower();
            string new_word = "";
            // convert to char array of the string
            char[] letters_input = input.ToCharArray();
            //Reconstruct the entire phrase from frint to back
            for (int i = input.Length - 1; i >= 0; i--)
            {
                new_word += letters_input[i];
                //Check if its okay
                //Console.WriteLine(letters_input[i]);
            }
            if (new_word == input)
            {
                Console.WriteLine("{0} is a palindrome!!!\nBecause {0} = {1}!!",
                input, new_word);
            }
            else
            {
                Console.WriteLine("{0} is not a palindrome.\nBecause {0} = {1}.",
                input, new_word);
            }
        }
    }
}







//--------------------------------------   Palindrome check (Improved version)   ------------------------------------------------//
namespace Collections_Mini_projects
{
    class Program1g
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a word: ");
            string input = Console.ReadLine().ToLower();
            char[] c = new char[] { '.', ',' }; //Creates an array for which to refer to
                                                //Removes spacingand items in list c for the front and back
            input = input.Trim();
            input = input.Trim(c);
            //Removes the spacing in between words by splitting them based on spacing
            string mods = "";
            string[] s = input.Split(' '); //So we are splitting based on the space.
            for (int i = 0; i <= s.Length - 1; i++) //Think delimeter by space :D
            {
                s[i] = s[i].Trim();
                s[i] = s[i].Trim(c);
                mods += s[i];
                //To check
                //Console.WriteLine(s[i]);
            }
            input = mods;
            string new_word = "";
            // convert to char array of the string
            char[] letters_input = input.ToCharArray();
            //Reconstruct the entire phrase from frint to back
            for (int i = input.Length - 1; i >= 0; i--)
            {
                new_word += letters_input[i];
                //Check if its okay
                //Console.WriteLine(letters_input[i]);
            }
            if (new_word == input)
            {
                Console.WriteLine("It is a palindrome!!!");
            }
            else
            {
                Console.WriteLine("It is not a palindrome.");
            }

        }
    }
}