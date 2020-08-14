using System;
using System.Threading;

namespace Hurdle
{

    class Program
    {

        static Grid grid = new Grid();

        static Obstacle[] obstacles = new Obstacle[3];
        static Runner runner = new Runner(5, 20);
        static int GameSpeed = 500;
        static bool Lost = false;
        static void Main(string[] args)
        {
            init();
            while (true)                            // game loop
            {
                while (!Console.KeyAvailable && !Lost)       // while no key is pressed .. Move!
                {
                    Logic();
                    Draw();
                    Lost = CheckLose();

                    if (Lost)
                    {
                        Console.Clear();
                        continue;
                    }
                    EndFrame();
                    Lost = CheckLose();

                }

                if (Lost)
                {
                    grid.MapPos(runner.BotPos, 'X');
                    Draw();
                    System.Console.WriteLine("You Lost!!");
                    System.Console.Read();
                }
                ConsoleKeyInfo cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.UpArrow && runner.JumpStatus == Runner.Status.NoHurdle)      // check if the up key is pressed .. JUMP!!
                {
                    // jump function should be here
                    runner.JumpStatus = Runner.Status.Animation1;
                    runner.Hurdle(grid);
                }
            }
        }

        static void init()
        {
            runner.Draw(grid);                          // draws runner

         Random random = new Random();
            // init random obstacle locations //
            int y_pos = 15;
            for (int i = 0; i < obstacles.Length; i++)
            {
                y_pos = y_pos + random.Next(6, 30);
                obstacles[i] = new Obstacle(5, y_pos);
                grid.MapPos(obstacles[i].pos, obstacles[i].ObstacleShape);                      // cteate Obstacle
            }
        }


        static void Logic()
        {
            foreach (Obstacle obs in obstacles)
            {
                obs.MoveLeft(grid);
                obs.CheckLineEnd(grid, ref GameSpeed);
            }
        }

        static void Draw()
        {
            grid.Draw();
        }

        static void EndFrame()
        {
            Thread.Sleep(GameSpeed);
            Console.Clear();
            if (runner.JumpStatus != Runner.Status.NoHurdle)
            {
                runner.Hurdle(grid);
            }
        }

        static bool CheckLose()
        {
            bool Lost = false;
            foreach (Obstacle obs in obstacles)
            {
                Lost = Lost || grid.CheckCollide(obs.pos, runner.BotPos);
                if (Lost)
                {
                    return true;
                }
            }

            return Lost;
        }
    }
}
