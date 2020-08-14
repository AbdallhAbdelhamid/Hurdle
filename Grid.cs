namespace Hurdle
{

    internal class Grid
    {
        public Grid()           // init the Grid Array with dots .....
        {
            for (int i = 0; i < height; i++)            //  columns
            {
                for (int j = 0; j < width; j++)       //  rows
                {
                    MapPos(i, j, GridShape);
                }
            }
        }

        public void Draw()
        {
            for (int j = 0; j < height; j++)            // draw rows
            {
                for (int i = 0; i < width; i++)       // draw cols
                {
                    System.Console.Write(GridArr[j, i].ToString());
                }
                System.Console.WriteLine(GridArr[height - 1, j].ToString());

            }
        }

        public void MapPos(int elementRow, int elementCol, char value)      // put element into the grid
        {
            GridArr[elementRow, elementCol] = value;
        }

        public void MapPos(int elementNumber, char value)
        {
            int row = elementNumber / width;         // get the element row
            int col = (elementNumber % width) - 1;   // get the element col
            GridArr[row, col] = value;
        }

        public void MapPos(int elementNumber)
        {
            MapPos(elementNumber, this.GridShape);
        }

        public void MapPos(int elementRow, int elementCol)
        {
            MapPos(elementRow, elementCol, this.GridShape);
        }

        public void MapPos(Pos pos, char value)
        {
            GridArr[pos.xPos, pos.yPos] = value;
        }

        public bool CheckCollide(Pos pos1, Pos pos2)
        {
            if (pos1.xPos == pos2.xPos && pos1.yPos == pos2.yPos)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public const int width = 110;
        public const int height = 7;
        private char[,] GridArr = new char[height, width];

        internal char GridShape
        {
            get;
            private set;
        } = '.';



    }





}