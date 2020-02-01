using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tetris2
{

    class Program
    {
        static public int[,] OldAction = new int[4, 2];
        static public int[,] ActiveAction = new int[4, 2];  //Координаты активной фигуры
        static public Byte[,] Place = new Byte[23, 10];
        static int Figure;                          // Переменная случайной генерации номера фигуры
        static Random Rand = new Random(6);
        static Boolean NeedSpawnForm;

        public static void Main(string[] args)
        {
            NeedSpawnForm = true;
            while (true)
            {
                SaveOldPosition();
                DrawField();
                Controller.Control();
                if (NeedSpawnForm == true)
                {
                    SpawnForm();
                }
                else
                {
                    DeleteOldForm();
                    FallForm();
                    if(Place[ActiveAction[0,1],ActiveAction[0,0]]!=1) DrawForm();

                }
                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    break;
                }
            }

            Console.WriteLine("\n GAME OVER");
            return;
        }


        public static void DrawField()
        {
            Thread.Sleep(100);
            Console.Clear();

            
            Console.WriteLine("Press 'ESCAPE' to exit ");
            for (int i = 0; i < 23; i++)
            {
                Console.Write("                             |");
                for (int j = 0; j < 10; j++)
                {
                    if (Tetris2.Program.Place[i, j] == 0)
                    {
                        Console.Write("  ");
                    }
                    else
                    {
                        if (Tetris2.Program.Place[i, j] == 1)
                        {
                            Console.Write(" H");
                        }
                        else Console.Write(" O");

                    }

                }
                Console.Write("|");
                if (i == 9)
                {
                    Console.Write(Tetris2.Program.Figure);
                }
                Console.Write("\n");
            }
            Console.Write("                             ----------------------");
        }
        public static void DeleteOldForm()
        {
            Place[OldAction[0, 1], OldAction[0, 0]] = 0;
            Place[OldAction[1, 1], OldAction[1, 0]] = 0;
            Place[OldAction[2, 1], OldAction[2, 0]] = 0;
            Place[OldAction[3, 1], OldAction[3, 0]] = 0;
        }

        public static void SaveOldPosition()
        {
            for (int i = 0; i <= 3; i++)
			{
                OldAction[i,0]=ActiveAction[i,0];
                OldAction[i,1]=ActiveAction[i,1];
			}
            
        }

        public static void FallForm()
        {
            Console.Write(ActiveAction[2, 1]);
            if (ActiveAction[3, 1] != 22 && ActiveAction[0, 1] != 22 && ActiveAction[1, 1] != 22 && ActiveAction[2, 0] != 22 && Place[ActiveAction[2, 1] + 1,ActiveAction[2, 0]] == 0 && Place[ActiveAction[3, 1] + 1, ActiveAction[3, 0]] == 0)
            {
                ActiveAction[0, 1]++;
                ActiveAction[1, 1]++;
                ActiveAction[2, 1]++;
                ActiveAction[3, 1]++;
            }

            else
            {
                NeedSpawnForm = true;
                DrawStaticForm();
                CheckFullLine();
            }
        }
        public static void CheckFullLine()
        {
            int ChekingLine = ActiveAction[0,1] ;
            int FullInLine = 0;
            for (int i = 0; i < 10; i++)
            {
                if (Place[ChekingLine,i]==1)
                {
                    FullInLine++;
                }
            }
            if (FullInLine==10)
            {
                for (int i = 0; i < 10; i++)
                {
                    Place[ChekingLine, i] = 0;
                }
            }
        }
        public static void DrawStaticForm()
        {
            Place[ActiveAction[0, 1], ActiveAction[0, 0]] = 1;
            Place[ActiveAction[1, 1], ActiveAction[1, 0]] = 1;
            Place[ActiveAction[2, 1], ActiveAction[2, 0]] = 1;
            Place[ActiveAction[3, 1], ActiveAction[3, 0]] = 1;
        }

        public  static void SpawnForm()
        {
            Tetris2.Program.Figure = Rand.Next(0, 2);
            switch (Figure)
            {
                case 0: //Квадрат
                    ActiveAction[0, 0] = 4; // Y koordinata             ОТЧЕТ ИДЕТ СЛЕВА НАПРАВО ПО Y СВЕРХУ ВНИЗ ПО Х
                    ActiveAction[0, 1] = 2; // X Верхняя Левая
                    ActiveAction[1, 0] = 5; // Y
                    ActiveAction[1, 1] = 2; // X Вернхняя Правая
                    ActiveAction[2, 0] = 4; // Y
                    ActiveAction[2, 1] = 3; // X Нижняя Левая
                    ActiveAction[3, 0] = 5; // Y
                    ActiveAction[3, 1] = 3; // X Нижняя Правая
                    DrawForm();
                    NeedSpawnForm = false;
                    break;
                case 1:
                    ActiveAction[0, 0] = 3;
                    ActiveAction[0, 1] = 3;
                    ActiveAction[1, 0] = 4;
                    ActiveAction[1, 1] = 2;
                    ActiveAction[2, 0] = 4;
                    ActiveAction[2, 1] = 3;
                    ActiveAction[3, 0] = 5;
                    ActiveAction[3, 1] = 3;
                    DrawForm();
                    NeedSpawnForm = false;
                    break;
                case 2:
                    ActiveAction[0, 0] = 3;
                    ActiveAction[0, 1] = 2;
                    ActiveAction[1, 0] = 3;
                    ActiveAction[1, 1] = 3;
                    ActiveAction[2, 0] = 4;
                    ActiveAction[2, 1] = 3;
                    ActiveAction[3, 0] = 4;
                    ActiveAction[3, 1] = 4;
                    DrawForm();
                    NeedSpawnForm = false;
                    break;
                    
                default:
                    break;
            }

        }
        public static void DrawForm()
        {
            Place[ActiveAction[0, 1], ActiveAction[0, 0]] = 2;
            Place[ActiveAction[1, 1], ActiveAction[1, 0]] = 2;
            Place[ActiveAction[2, 1], ActiveAction[2, 0]] = 2;
            Place[ActiveAction[3, 1], ActiveAction[3, 0]] = 2;
        }
      


    }

}
