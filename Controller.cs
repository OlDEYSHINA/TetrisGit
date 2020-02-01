using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris2
{
    class Controller
    {
        public static void Control()
        {
            if (Console.ReadKey(true).Key == (ConsoleKey.LeftArrow))
            {
                MoveLeft();
            }
            if (Console.ReadKey(true).Key == (ConsoleKey.RightArrow))
            {
                MoveRight();
            }
            /* if (Console.ReadKey(true).Key ==(ConsoleKey.LeftArrow | ConsoleKey.RightArrow |ConsoleKey.DownArrow))
             switch (Console.ReadKey(true).Key)
             {
                 case ConsoleKey.LeftArrow:
                     MoveLeft();
                     break;
                 case ConsoleKey.RightArrow:
                     MoveRight();
                     break;
                 default:
                     break;
             }*/
        }
        public static void MoveLeft()
        {
            Console.WriteLine("Влево");
           /* if ()
            if (Tetris2.Program.Place[Program.ActiveAction[0, 1], Program.ActiveAction[0, 0]] == 0)
            {
                break;
            }*/
            Tetris2.Program.ActiveAction[0, 0]--;
            Tetris2.Program.ActiveAction[1, 0]--;
            Tetris2.Program.ActiveAction[2, 0]--;
            Tetris2.Program.ActiveAction[3, 0]--;
        }
        public static void MoveRight()
        {
            Console.WriteLine("Вправо");
            Tetris2.Program.ActiveAction[0, 0]++;
            Tetris2.Program.ActiveAction[1, 0]++;
            Tetris2.Program.ActiveAction[2, 0]++;
            Tetris2.Program.ActiveAction[3, 0]++;
        }
    }
}
