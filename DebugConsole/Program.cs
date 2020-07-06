using System;
using TournamentLibrary.Models.Score;

namespace DebugConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Score score = new Score(1f, 0);

            for (int i = 0; i < 100; i++)
            {
                score *= 11;
                Console.WriteLine(score);
            }
        }
    }
}
