


namespace Hurdle
{
    class Obstacle
    {
        public Obstacle(Pos pos_in)
        {
            pos = pos_in;
        }

        public void MoveLeft()
        {
            pos.yPos--;
        }
        
        internal Pos pos;
        
        internal char ObstacleShape
        {
            get;
            
        } = '|';

    }



}