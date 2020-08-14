using System;
using System.Threading;

namespace Hurdle
{

    class Program
    {

        static Grid grid = new Grid();

        static Obstacle[] obstacles = new Obstacle[4];
        static Runner runner = new Runner(5, 20);
        static int GameSpeed = 500;
        static bool Lost = false;

        const int OBSTACLE_COL_START_POSITION = 15;
        const int OBSTACLE_ROW_START_POSITION = 5;

        const int OBSTACLE_MIN_COL_VALUE = 6;
        const int OBSTACLE_MAX_COL_VALUE = 30;
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
            /*** init random obstacle locations ***/
            Random random = new Random();
            int y_pos = OBSTACLE_COL_START_POSITION;
            for (int i = 0; i < obstacles.Length; i++)
            {
                y_pos = y_pos + random.Next(OBSTACLE_MIN_COL_VALUE, OBSTACLE_MAX_COL_VALUE);
                obstacles[i] = new Obstacle(OBSTACLE_ROW_START_POSITION, y_pos);
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
            runner.Draw(grid);             // draws runner
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
