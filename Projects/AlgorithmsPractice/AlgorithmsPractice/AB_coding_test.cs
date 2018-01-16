using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickTest
{
	public class Marbles
	{
		private static readonly Random mRandom = new Random(); // use to generate random color marble

		public const int RED_MARBLE = 1;
		public const int BLUE_MARBLE = 2;
		public const int GREEN_MARBLE = 3;
		public const int ORANGE_MARBLE = 4;

		static void Main(string[] args)
		{
			int red, green, blue, orange;

			red = PromptInt("Ratio red marbles?");
			green = PromptInt("Ratio green marbles?");
			blue = PromptInt("Ratio blue marbles?");
			orange = PromptInt("Ratio orange marbles?");

			int[] results = Solve(red, green, blue, orange, 1000);
			WriteOutStats(results);
		}

		public static int PromptInt(string message)
		{
			int ret = -1;
			while (true)
			{
				Console.WriteLine(message);
				string str = Console.ReadLine();
				if (Int32.TryParse(str, out ret))
					break;
				else
					Console.WriteLine("'{0}' is invalid", str);
			}
			return ret;
		}

		public static int[] Solve(int red, int green, int blue, int orange, int count)
		{
            // TOOD: Return an array of integers of length [count]
            // each element in the array should contain a value from 1 to 4
            // the value represents a marble color (see constants above)
            // using the passed in values, you need to infer the probablility of each colored marble.
            // You should then *randomly* generate [count] number of marbles based on that probability

            // (i.e. if you were passed the values 10, 5, 5, 1 for the red, green, blue and orange parameters respectively
            // you should have approximately 10 red marbles for every 5 green and for every five blue marbles, and
            // there should 10 red marbles for approximately every orange marble you get)

            //This part establishes the % chance of drawing a marble and gives it a range 
            double total = red + green + blue + orange;
            double redRange = (red / total)*100;
            double greenRange = redRange + (green / total)*100;
            double blueRange =  greenRange + (blue / total)*100;
            double orangeRange = blueRange + (orange / total)*100;

			
            int[] resultArray = new int[count];
            Random randomNum = new Random();

            for (int i = 0; i < count; i++)
            {
                double random = randomNum.NextDouble() * (100);

				if (random <= redRange)
                    resultArray[i] = 1;
                else if (random <= greenRange)
                    resultArray[i] = 2;
                else if (random <= blueRange)
                    resultArray[i] = 3;
                else
                    resultArray[i] = 4;
            }

            return resultArray;
           // return new int[0];
		}

		public static void WriteOutStats(int[] results)
		{
            // TODO: output the total number of red, green, blue and orange marbles based on the array of results passed into you.
            // This array is the same array you generated in the Solve function above.
            int redCount = 0;
            int greenCount = 0;
            int blueCount = 0;
            int orangeCount = 0;

            foreach (var i in results)
            {
                switch (i)
                {
                    case 1:
                        redCount += 1;
                        break;
                    case 2:
                        greenCount += 1;
                        break;
                    case 3:
                        blueCount += 1;
                        break;
                    default:
                        orangeCount += 1;
                        break;
                }
            }

            Console.WriteLine(String.Format("You have {0} red, {1} green, {2} blue and {3} orange marbles", redCount, greenCount, blueCount, orangeCount));
        }

	}
}