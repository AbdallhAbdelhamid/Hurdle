using System;


namespace Hurdle
{
    class Obstacle
    {
        public Obstacle(Pos pos_in)
        {
            pos = pos_in;
        }
        public Obstacle(int x_pos, int y_pos)
        {
            pos = new Pos(x_pos, y_pos);
        }



        public void MoveLeft(Grid grid)
        {
            grid.MapPos(pos, grid.GridShape);
            MoveLeft();
            grid.MapPos(pos, ObstacleShape);
        //    CheckLineEnd(grid);
        }

        public void CheckLineEnd(Grid grid,ref int GameSpeed)
        {
            if (pos.yPos == 0)        // 0 equals end of line on the left
            {
                grid.MapPos(pos, grid.GridShape);

                pos.yPos = random.Next(40,Grid.width);
                GameSpeed -= 50;
            }
        }


        private void MoveLeft()
        {
            pos.yPos--;
        }

        public Pos pos;

        internal char ObstacleShape
        {
            get;
            private set;
        } = '|';

        Random random = new Random();


    }

}