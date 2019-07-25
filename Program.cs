using System;
using System.Collections.Generic;

namespace Lab9RefactoringTime_NateS
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> alName = new List<string>()
                { "Ashwin Oliver", "Cassie Newton", "Shawnie Salter", "Stephen Bolton", "Ralphy Loyd", "Jodi Cain", "Sumayyah Dalby", "Nabeela Houghton", "Aanya Schmitt", "Ivan Holt" };
            List<string> alHome = new List<string>()
                { "Mesa,Arizona", "Troy,Michigan", "New Orleans,Louisiana", "Flint,Michigan", "Washington,District of Colombia", "Roseville, Michigan", "Fresno, California", "Dallas, Texas", "Ann Arbor,Michigan", "Charlotte, North Carolina" };
            List<string> alFood = new List<string>()
                { "Apple Pie", "Apple Crumble", "Macoroni and Cheese", "Chicken", "Fried Shrimp", "Chili Con Carne", "Pizza", "Steak", "Tacos", "Kiwi" };
            List<string> alColor = new List<string>()
                { "Green", "Blue", "Black", "Orange", "Red", "Pink", "Green", "Blue", "Black", "Orange" };
            List<string> alAge = new List<string>()
                { "19", "23", "21", "28", "25", "24", "30", "20", "28", "29" };


            Console.WriteLine("Welcome to the class.");
            bool rep = true;
            while (rep)
            {

                int rep2 = GetChoice("Would you like to ask about a student or add another student?(A/B)");
                if (rep2 == 1)
                {
                    int i = 1;
                    foreach (string name in alName)
                    {
                        Console.WriteLine($"{i}:{name} ");
                        i++;
                    }

                    int choice = GetNumChoice(alName);
                    PrintInfo(choice, alName, alHome, alFood, alColor, alAge);
                }
                else if (rep2 == 2)
                { 

                        alName.Add( GetString("What is their name?"));

                        alHome.Add( GetString("Where are they from?"));

                        alFood.Add( GetString("What is their favorite food?"));

                        alAge.Add( GetString("What is their age?"));

                        alColor.Add( GetString("What is their favorite color?"));
 
                }
                else
                {
                    rep2 = GetChoice("Sorry I didn't get that!(A/B)");
                }
                rep = GetYesNo("Would you like to repeat the process?");
            }

            Console.WriteLine("Have a good day  then.(Press any key to exit)");

            Console.ReadKey(true);

        }
        public static int GetNumChoice(List<string> Name)
        {
            Console.WriteLine($"What Student would you like to learn about?(Name or number 1-{Name.Count})");

            string choice = Console.ReadLine();

            int result;

            bool isValid = int.TryParse(choice, out result);

            
            
            
                if(!isValid)
                { 
                    for (int i = 0; i < 10; i++)
                    {
                        if (Name[i].ToString() == choice)
                        {
                            return i;
                        }
                    }
                }
                else if(isValid && result > 0 && result <= Name.Count)
                {
                    return result - 1;
                }
                Console.WriteLine("Sorry I didn't get that!");
                return GetNumChoice(Name);
            
        }
        public static void PrintInfo(int i, List<string> Name, List<string> Home, List<string> Food, List<string> Color, List<string> Age)
        {
            // provides name age, the hometown and/or fav food

            Console.WriteLine($"{Name[i]}, is {Age[i]} years old.");

            int choice = GetChoice("Would you like to know their hometown, favorite food, or favorite color?(A/B/C)");

            if (choice == 1)
            {
                Console.WriteLine($"{Name[i]} is from {Home[i]}.");
            }
            else if (choice == 2)
            {
                Console.WriteLine($"{Name[i]} favorite food is {Food[i]}");
            }
            else
            {
            Console.WriteLine($"{Name[i]} favorite color is {Color[i]}");
            }
            bool rep = GetYesNo("Would you like more info?");
            if (rep)

            {
                PrintInfo(i, Name, Home, Food, Color, Age);
            }
        }
        public static bool GetYesNo(string message)
        {
            Console.WriteLine($"{message}(Y/N)");
            if (Console.ReadKey(true).Key == ConsoleKey.Y)
            {
                return true;
            }
            else if (Console.ReadKey(true).Key == ConsoleKey.N)
            {
                return false;
            }
            else
            {
                return GetYesNo("Not Valid");
            }
        }
        public static int GetChoice(string message)
        {
            Console.WriteLine($"{message}");
            if (Console.ReadKey(true).Key == ConsoleKey.A)
            {
                return 1;
            }
            else if (Console.ReadKey(true).Key == ConsoleKey.B)
            {
                return 2;
            }
            else if (Console.ReadKey(true).Key == ConsoleKey.C)
            {
                return 3;
            }
            else
            {
                return GetChoice("Not Valid");
            }
        }
        public static List<string> FillArrayList(List<string> al, string[] s)
        {
            
            foreach (string str in s)
            {
                al.Add(str);
            }
            return al;
        }
        public static string GetString(string message)
        {
            Console.WriteLine(message);
            string result = Console.ReadLine();

            if (result != null && result != " " && result != "")
            {
                return result;
            }
            else
            {
                return GetString("Not Valid!");
            }
        }

    }
   
}
