namespace Hurdle
{

    internal class Grid
    {
        public Grid()
        {
            for (int i = 0; i < height; i++)            //  column
            {
                for (int j = 0; j < width; j++)       //  row
                {
                    MapPos(i, j, '.');
                }
            }
        }

        public void Draw()
        {
            for (int j = 0; j < height; j++)            // draw row
            {
                for (int i = 0; i < width; i++)       // draw col
                {
                    System.Console.Write(GridArr[j, i].ToString());
                }
                System.Console.WriteLine(GridArr[height - 1, j].ToString());

            }
        }

        public void MapPos(int elementRow, int elementCol, char value)
        {
            GridArr[elementRow, elementCol] = value;
        }

        public void MapPos(int elementNumber, char value)
        {
            int row = elementNumber / width;         // get the element row
            int col = (elementNumber % width) - 1;   // get the element col
            GridArr[row, col] = value;
        }

        public void MapPos(Pos pos, char value)
        {
            GridArr[pos.xPos, pos.yPos] = value;
        }



        const int width = 110;
        const int height = 7;
        private char[,] GridArr = new char[height, width];



    }





}