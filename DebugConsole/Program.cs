using System;
using TournamentLibrary.Models.Score;

namespace DebugConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Score score = new Score(900f, 3);
            Score scoreB = new Score(250f, 2);
            Score scoreC = new Score(123f, 2);
            Score scoreD = new Score(123f, 1);
            Console.WriteLine(score - scoreB);
            Console.WriteLine(scoreB - score);
            for (int i = 0; i < 10; i++)
            {
                scoreC -= scoreB;
                Console.WriteLine(scoreC);
            }
        }
    }
}
