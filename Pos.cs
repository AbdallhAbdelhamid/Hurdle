namespace Hurdle
{
    internal class Pos
    {
        internal Pos()           // default values // constructer
        {
            xPos = 0;
            yPos = 0;
        }
        internal Pos(int xpos , int ypos) // parametrized constructers
        {
            xPos = xpos;
            yPos= ypos;
        }
        
        internal int xPos
        {
           get;
           set;
        }
        internal int yPos
        {
            get;
            set;
        }

    }
}