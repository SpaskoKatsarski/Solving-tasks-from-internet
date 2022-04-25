using System;
using System.Linq;

namespace T._16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] track = Console.ReadLine().Split().Select(int.Parse).ToArray();

            double leftSum = 0;
            double rightSum = 0;

            for (int i = 0; i < track.Length / 2; i++)
            {
                double currentStage = track[i];

                if (currentStage == 0)
                {
                    leftSum *= 0.8;
                }
                else
                {
                    leftSum += currentStage;
                }
            }

            // 1 2 3 4 5

            for (int i = track.Length - 1; i > track.Length / 2; i--)
            {
                double currentStage = track[i];

                if (currentStage == 0)
                {
                    rightSum *= 0.8;
                }
                else
                {
                    rightSum += currentStage;
                }
            }

            string winnerSide = string.Empty;
            double winnerTime = 0;

            if (leftSum < rightSum)
            {
                winnerSide = "left";
                winnerTime = leftSum;
            }
            else
            {
                winnerSide = "right";
                winnerTime = rightSum;
            }

            Console.WriteLine($"The winner is {winnerSide} with total time: {winnerTime}");
        }
    }
}
