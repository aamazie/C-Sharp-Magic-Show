using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var now = DateTime.UtcNow;
            Console.WriteLine("It is currently {0} UTC time now.", now);

            bool moreFB = true;
            while (moreFB == true)
            {
                Console.WriteLine("Put in the amount you would like to FizzBuzz up to:");
                Console.WriteLine();

                int num;

                num = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                fizzbuzz(num);
                Console.WriteLine();
                Console.WriteLine("Want to input another number to FizzBuzz to?");
                string infoAnswer = Console.ReadLine().ToLower();
                if (infoAnswer.Contains("n"))
                {
                    moreFB = false;
                }
            }
            Console.WriteLine();


            Console.WriteLine("Ok! Now time to fill our imaginary database with our employees!");

            bool moreEmployees = true;
            while (moreEmployees == true)
            {
                Console.WriteLine("What's this employee's first name?");
                string firstName = Console.ReadLine();
                Console.WriteLine("What's this employee's last name?");
                string lastName = Console.ReadLine();
                string newName = firstName + " " + lastName;
                Console.WriteLine("What's this employee's role?");
                string newRole = Console.ReadLine();
                Console.WriteLine("What's this employee's salary? Just numbers.");
                double newSalary = Convert.ToDouble(Console.ReadLine());
                Employee newEmp = new Employee(newName, newRole, newSalary);
                Console.WriteLine();
                Console.WriteLine("This employee is {0}. Their position is {1}. They make ${2}",newEmp.name, newEmp.role, newEmp.salary);
                Console.WriteLine("There are {0} employees that you've put in the system", Employee.getNumOfEmployees());
                Console.WriteLine();
                Console.WriteLine("Want to input another employee's information?");
                string infoAnswer = Console.ReadLine().ToLower();
                if (infoAnswer.Contains("n"))
                {
                    moreEmployees = false;
                }
            }
            Console.WriteLine();


            Console.WriteLine("Another trick! I will tell you if a word you give me is a PALINDROME!");

            bool morePal = true;
            while (morePal == true)
            {
                Console.WriteLine("Give me a word:");
                string palCheck = Console.ReadLine().ToLower();
                char[] backwardCheck = palCheck.ToCharArray();
                Array.Reverse(backwardCheck);
                string revStr = new string(backwardCheck);
                if (revStr == palCheck)
                {
                    Console.WriteLine("Yup. It's a palindrome.");
                }
                else
                {
                    Console.WriteLine("Nope. Not a palindrome.");
                }
                Console.WriteLine();
                Console.WriteLine("Want to see if another word is a palindrome?");
                string infoAnswer = Console.ReadLine().ToLower();
                if (infoAnswer.Contains("n"))
                {
                    morePal = false;
                }
            }
            Console.WriteLine();



            Console.WriteLine("A different trick! I will tell you if 2 words you give me are ANAGRAMS!");

            bool moreAna = true;
            while (moreAna == true)
            {
                Console.WriteLine("Give me a word:");
                string anaCheck1 = Console.ReadLine().ToLower();
                Console.WriteLine("Give me the second word:");
                string anaCheck2 = Console.ReadLine().ToLower();
                string ana1 = String.Concat(anaCheck1.OrderBy(c => c));
                string ana2 = String.Concat(anaCheck2.OrderBy(c => c));
                if (ana1 == ana2)
                {
                    Console.WriteLine("Yup. Those words are anagrams of each other.");
                }
                else
                {
                    Console.WriteLine("Nope. Not an anagram.");
                }
                Console.WriteLine();
                Console.WriteLine("Want to see if more words are anagrams?");
                string infoAnswer = Console.ReadLine().ToLower();
                if (infoAnswer.Contains("n"))
                {
                    moreAna = false;
                }
            }
            Console.WriteLine();



            Console.WriteLine("And now for my final trick!");
            Console.WriteLine("I will tell you if a sum can be found from 2 numbers in a given list of numbers.");

            bool moreSum = true;
            while (moreSum == true)
            {
                Console.WriteLine("First, give me the sum you want to look for:");
                double givenSum = Convert.ToDouble(Console.ReadLine());

                List<double> sumList = new List<double>();
                Console.WriteLine("Now give me the first number to put into the list:");
                sumList.Add(Convert.ToDouble(Console.ReadLine()));

                Console.WriteLine("Good. Give me another number:");
                sumList.Add(Convert.ToDouble(Console.ReadLine()));

                Console.WriteLine("Ok. Give me another number:");
                sumList.Add(Convert.ToDouble(Console.ReadLine()));

                Console.WriteLine("Alright. Give me one more number:");
                sumList.Add(Convert.ToDouble(Console.ReadLine()));

                if (sumFinder(sumList, givenSum) == true)
                {
                    Console.WriteLine("Yes! Two numbers in that list do equal the sum!");
                }
                else
                {
                    Console.WriteLine("Sorry. Two numbers in that list don't equal the sum. :/ ");
                }
                Console.WriteLine();
                Console.WriteLine("Want to try to find if more lists have sums?");
                string infoAnswer = Console.ReadLine().ToLower();
                if (infoAnswer.Contains("n"))
                {
                    moreSum = false;
                }
            }


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Thank you! Hit any key to exit!");
            Console.ReadKey();
        }

        public static void fizzbuzz(int upto)
        {
            upto++;

            for (int i = 1; i < upto; i++)
            {
                if ((i % 3 == 0) && (i % 5 == 0))
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }

        public static bool sumFinder(List<double> theList, double theSum)
        {

            List<double> comp = new List<double>();
            for (int n = 0; n < theList.Count; n++)
            {
                for (int i = 0; i < comp.Count; i++)
                {
                    if (theList[n] == comp[i])
                    {
                        return true;
                    }
                }
                comp.Add(theSum - theList[n]);
            }
            return false;
        }
    }

    class Employee
    {
        public string name;
        public string role;
        public double salary;

        public Employee(string name, string role, double salary)
        {
            this.name = name;
            this.role = role;
            this.salary = salary;

            numOfEmployees++;
        }

        static int numOfEmployees;

        public static int getNumOfEmployees()
        {
            return numOfEmployees;
        }
    }
}
