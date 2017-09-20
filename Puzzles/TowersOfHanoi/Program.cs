using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowersHanoi
{
    public class Program
    {
        static void Main(string[] args)
        {
            int minValue = 1;
            int maxValue = 16;

            if (args == null || args.Length != 2)
            {
                Console.WriteLine($"Usage: TowersHanoi.exe [int number of disks from {minValue} to {maxValue}] [bool display game state]");
                return;
            }

            int diskCount = 0;
            bool displayGameState = false;

            try
            {
                displayGameState = bool.Parse(args[1]);
            }
            catch (FormatException fe)
            {
                Console.WriteLine($"Error: {fe.Message} Please enter 'true' or 'false' for the display game state flag");
                return;
            }

            if (Int32.TryParse(args[0], out diskCount))
            {
                if (diskCount >= minValue && diskCount <= maxValue)
                {
                    var gameBoard = new TowersGameBoard(diskCount, displayGameState);
                    Stopwatch sw = Stopwatch.StartNew();
                    gameBoard.Play();
                    sw.Stop();
                    Console.WriteLine($"Elapsed milliseconds: {sw.ElapsedMilliseconds}");
                }
                else
                {
                    Console.WriteLine($"Please enter a number of disks from {minValue} to {maxValue}");
                }
            }
        }
    }
}
