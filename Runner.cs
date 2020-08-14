
using System.Threading;

namespace Hurdle
{

    internal class Runner
    {
        public enum Status
        {
            Animation1,
            Animation2,
            Animation3,
            Animation4,
            Animation5,
            Animation6,
            Animation7,
            NoHurdle
        }

        public Runner(Pos pos_in)
        {
            BotPos = pos_in;
        }

        public Runner(int bot_x_pos, int bot_y_pos)
        {
            BotPos = new Pos(bot_x_pos, bot_y_pos);
            CenterPos = new Pos(bot_x_pos - 1, bot_y_pos);
            TopPos = new Pos(bot_x_pos - 2, bot_y_pos);

        }

        public void Draw(Grid grid)
        {
            grid.MapPos(BotPos, RunnerShape);                    // create runner
            grid.MapPos(TopPos, RunnerShape);                     // create runner
            grid.MapPos(CenterPos, RunnerShape);                    // create runner
        }
        public void Hurdle(Grid grid)
        {
            // animation 1
            if (this.JumpStatus == Runner.Status.Animation1)
            {
                // top pos
                grid.MapPos(TopPos, grid.GridShape);
                TopPos.yPos++;
                grid.MapPos(TopPos, RunnerShape);


                // set to next animation
                Thread.Sleep(10);

                this.JumpStatus = Runner.Status.Animation2;
            }

            // animation 2 // second jump
            else if (this.JumpStatus == Runner.Status.Animation2)
            {
                // top pos
                grid.MapPos(TopPos, grid.GridShape);
                TopPos.yPos++;
                grid.MapPos(TopPos, RunnerShape);

                // mid pos
                grid.MapPos(CenterPos, grid.GridShape);
                CenterPos.xPos--;
                CenterPos.yPos++;
                grid.MapPos(CenterPos, RunnerShape);

                // bot pos

                grid.MapPos(BotPos, grid.GridShape);
                BotPos.xPos--;
                grid.MapPos(BotPos, RunnerShape);

                // set to next animation
                this.JumpStatus = Runner.Status.Animation3;
                Thread.Sleep(10);

            }

            else if (this.JumpStatus == Runner.Status.Animation3)
            {
                // top pos
                grid.MapPos(TopPos, grid.GridShape);
                TopPos.yPos++;
                grid.MapPos(TopPos, RunnerShape);

                // mid pos
                grid.MapPos(CenterPos, grid.GridShape);
                CenterPos.yPos++;
                grid.MapPos(CenterPos, RunnerShape);

                // bot pos

                grid.MapPos(BotPos, grid.GridShape);
                BotPos.xPos--;
                BotPos.yPos++;
                grid.MapPos(BotPos, RunnerShape);

                // set to next animation
                this.JumpStatus = Runner.Status.Animation4;
                Thread.Sleep(10);

            }


            else if (this.JumpStatus == Runner.Status.Animation4)
            {
                // top pos

                grid.MapPos(TopPos, grid.GridShape);
                TopPos.xPos++;
                TopPos.yPos++;

                grid.MapPos(TopPos, RunnerShape);

                // mid pos
                grid.MapPos(CenterPos, grid.GridShape);
                CenterPos.yPos++;
                grid.MapPos(CenterPos, RunnerShape);

                // bot pos
                grid.MapPos(BotPos, grid.GridShape);
                BotPos.yPos++;
                grid.MapPos(BotPos, RunnerShape);

                // set to next animation
                this.JumpStatus = Runner.Status.Animation5;
                Thread.Sleep(10);

            }
            // animation 5

            else if (this.JumpStatus == Runner.Status.Animation5)
            {
                // top pos

                grid.MapPos(TopPos, grid.GridShape);
                TopPos.xPos++;
                grid.MapPos(TopPos, RunnerShape);

                // mid pos
                grid.MapPos(CenterPos, grid.GridShape);
                CenterPos.xPos++;
                CenterPos.yPos++;
                grid.MapPos(CenterPos, RunnerShape);

                // bot pos
                grid.MapPos(BotPos, grid.GridShape);
                BotPos.yPos++;
                grid.MapPos(BotPos, RunnerShape);

                // set to next animation
                this.JumpStatus = Runner.Status.Animation6;
                Thread.Sleep(10);

            }
            // animation 6

             else if (this.JumpStatus == Runner.Status.Animation6)
            {
                // top pos
                // mid pos
            
                // bot pos
                grid.MapPos(BotPos, grid.GridShape);
                BotPos.yPos++;
                grid.MapPos(BotPos, RunnerShape);

                // set to next animation
                this.JumpStatus = Runner.Status.NoHurdle;
                Thread.Sleep(10);

                Pos temp = BotPos;
                BotPos = TopPos;
                TopPos = temp;
            }
        }



        public void Jump(Grid grid)
        {
            if (this.JumpStatus == Runner.Status.Animation1)
            {
                grid.MapPos(BotPos, grid.GridShape);       // replace old pos with dot
                MoveUp();                      // runner changes pos 
                grid.MapPos(BotPos, this.RunnerShape);       // create the runner
                this.JumpStatus = Runner.Status.Animation2;
            }
        }

        public void Return(Grid grid)
        {
            grid.MapPos(BotPos, grid.GridShape);
            MoveDown();
            grid.MapPos(BotPos, RunnerShape);
        }

        private void MoveUp()          // moves up.
        {
            BotPos.xPos--;
        }

        public void MoveDown()
        {
            BotPos.xPos++;
        }

        public Pos BotPos
        {
            get;
            private set;
        }

        public Pos TopPos
        {
            get;
            private set;
        }


        public Pos CenterPos
        {
            get;
            private set;
        }








        internal char RunnerShape
        {
            get;
            private set;
        } = '*';

        public Status JumpStatus = Runner.Status.NoHurdle;




    }





}