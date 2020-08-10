using System;
using System.Threading;

namespace Hurdle
{
    class Program
    {
        static Grid grid = new Grid();

        static Obstacle obs1 = new Obstacle(new Pos(3, 7));
        
        static void Main(string[] args)
        {
            init();
            while (true)                            // game loop
            {
                while (!Console.KeyAvailable)       // while no key is pressed .. Move!
                {
                    Logic();
                    Draw();
                    bool on = CheckCollide(obs1.pos,new Pos(3,2));
                    if (on)
                    {
                        System.Console.WriteLine("You Lost!!");
                        System.Console.Read();
                    }
                    Clear();

                }

                ConsoleKeyInfo cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.UpArrow)      // check if the up key is pressed .. JUMP!!
                {
                    // jump function should be here
                    //  runner.Jump();
                }
            }
        }

        static void init()
        {
            grid.MapPos(3, 2, 'P');                                            // spawn runner
            grid.MapPos(obs1.pos, obs1.ObstacleShape);                      // spawn Obstacle
        }


        static void Logic()
        {
            MoveObstacleLeft(obs1);
        }

        static void Draw()
        {
            grid.Draw();
        }

        static void Clear()
        {
            Thread.Sleep(250);
            Console.Clear();
        }

        static void MoveObstacleLeft(Obstacle obs)
        {
            grid.MapPos(obs.pos, '.');
            obs1.MoveLeft();
            grid.MapPos(obs.pos, obs.ObstacleShape);
        }


        static bool CheckCollide(Pos pos1, Pos pos2)
        {
            if (pos1.xPos == pos2.xPos && pos1.yPos == pos2.yPos)
            {
            grid.MapPos(pos1, 'X');
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
