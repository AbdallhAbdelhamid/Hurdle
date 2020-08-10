namespace Hurdle
{
    internal class Pos
    {
        internal Pos()           // default values
        {
            xPos = 0;
            yPos = 0;
        }
        internal Pos(int xpos , int ypos)
        {
            xPos = xpos;
            yPos= ypos;
        }
        
        public int xPos
        {
           get;
           set;
        }
        public int yPos
        {
            get;
            set;
        }

    }
}