using System;
using System.Linq;
using Battleships.Business.Grids;
using Battleships.Helpers;
using Battleships.IServices.Inputs;

namespace Battleships.Services.Inputs
{
    public class ConsoleIUIService : IUIService
    {
        public string GetGridSquareIdInput()
        {
            Console.Write("Enter grid square coordinates: ");
            return Console.ReadLine()?.ToUpper();
        }

        public void NotifyAboutGameStart()
        {
            Console.WriteLine("Game starts!");
        }

        public void NotifyAboutShotOnTarget()
        {
            Console.WriteLine("Shot on target!");
        }

        public void NotifyAboutShotMissed()
        {
            Console.WriteLine("Shot missed :(");
        }

        public void NotifyAboutGameFinish()
        {
            Console.WriteLine("Game finished!");
        }

        public void RefreshGrid(Grid grid)
        {
            Console.WriteLine("=========================");
            Console.Write("  ");
            for (var i = 0; i < grid.ColumnCount; i++)
            {
                Console.Write(i.GetColumnName().PadRight(2));
            }


            foreach (var gridSquare in grid.GridSquares.OrderBy(_ => _.Y).ThenBy(_ => _.X))
            {
                if (gridSquare.X == 0)
                {
                    Console.WriteLine();
                    Console.Write(gridSquare.Y.GetRowName().PadRight(2));
                }

                if (gridSquare.WasShot && gridSquare.Ship != null)
                    Console.Write("X ");
                else if(gridSquare.WasShot)
                    Console.Write("- ");
                else
                    Console.Write(". ");
            }

            Console.WriteLine();
        }
    }
}