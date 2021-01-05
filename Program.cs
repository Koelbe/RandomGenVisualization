using System;
using System.Threading;

namespace RandomGenVisualizer
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int currentNumber = 0;

            //Default values
            int randomMin = -1;
            int randomMax = 1;
            int sleepTime = 1;
            askUserForGenerationSettings();

            while(true) //Loop time
            {

                //These two if statements print out a line of colored ')' characters
                //The number of ')' printed is equal to currentNumber
                //If currentNumber is positive, prints green
                //If currentNumber is negative, prints red

                printCurrentNumberVisualization();
                currentNumber += random.Next(randomMin,randomMax);//Lowers or raises currentNumber by custom random number in range
                Thread.Sleep(sleepTime);//Customizable delay
            }

            void askUserForGenerationSettings()
            {
                try
                {
                    Console.Write("randomMin: ");
                    randomMin = int.Parse(Console.ReadLine());
                    Console.Write("randomMax: ");
                    randomMax = int.Parse(Console.ReadLine()) + 1; //+1 to make max included in random range, not excluded
                    if (randomMax <= randomMin) { throw new Exception(); }
                    Console.Write("sleepTime: ");
                    sleepTime = int.Parse(Console.ReadLine());
                }
                catch(Exception e)
                {
                    Console.WriteLine("Something went wrong, defaulting to default values.");
                    randomMin = -1;
                    Console.WriteLine("randomMin: -1");
                    randomMax = 1+1;//+1 to make max included in random range, not excluded
                    Console.WriteLine("randomMax: 1");
                    sleepTime = 1;
                    Console.WriteLine("sleepTime: 1");
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                }
                
            }

            void printCurrentNumberVisualization() 
            {

                if (currentNumber > 0) //Positive, Green
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(currentNumber);
                    for (int length = 1; length <= currentNumber; length++)
                    {
                        Console.Write(")");
                    }
                }

                if (currentNumber < 0) //Negative, Red
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(currentNumber);
                    for (int length = 1; length <= currentNumber * -1; length++)
                    {
                        Console.Write(")");
                    }
                }
                Console.WriteLine();
            }

        }
    }
}
