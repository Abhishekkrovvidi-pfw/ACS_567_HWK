using System;
using System.IO;

namespace ConsoleApp1
{
    internal class Program
    {
        public static string filepath = @"X:\SPM\ACS_567_HWK\HWK1B\steps.txt";
        public static string Content = "(Empty File)";
        public static bool Run = true;
        public static int Choice = 0;
        public static string Input = "";


        static void ColorText(string Message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(Message);
            Console.ResetColor();
        }



        static void Main(string[] args)
        {
            Console.Title = "Daily Fitness";
            while (Run == true)
            {
                menu();
            }

        }
        static void menu()
        {
            string Input = "";
            int Choice = 0;

            Console.WriteLine("\n\n\n\n\n-------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(" 1) Read Data  2)Update Data 3) Mean 4) Total Steps 5)Exit ");

            Input = Console.ReadLine();
            Choice = Convert.ToInt32(Input);

            if (Choice == 1)
            {
                Console.Clear();
                if (File.Exists(filepath))
                {
                    ColorText("\n\n Number of steps you made in this week are");
                    Content = File.ReadAllText(filepath);
                }
                Console.WriteLine(Content);

            }

            else if (Choice == 2)
            {
                Console.Clear();
                ColorText("\n\nEnter todays steps and press enter to save it:");
                Input = Console.ReadLine();
                Content += "\n" + Input;
                ColorText("\nConfirm that the file contents will be updated.\nType Y or N:");

                Input = Console.ReadLine();
                Input = Input.ToLower();

                if (Input == "y")
                {
                    File.WriteAllText(filepath, Content);
                    ColorText("File updated.");
                }
                else
                {
                    ColorText("File not updated.");
                }
            }
            else if (Choice == 3)
            {
                Console.Clear();



            }
            else if (Choice == 4)
            {
                Console.Clear();



            }
            else if (Choice == 5)
            {
                Console.Clear();

                Run = false;

            }
            else
            {

                Console.WriteLine("Choose a number between 1-4");
            }

        }


    }
}


