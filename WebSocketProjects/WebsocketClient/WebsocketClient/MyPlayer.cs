using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebsocketClient
{
    public class MyPlayer
    {
        private bool isUpPressed = false;
        private bool isDownPressed = false;
        private bool isLeftPressed = false;
        private bool isRightPressed = false;

        public static int speed = 20;
        public static int angle = 0;
        public static double mod = 0;

        public Player player;

        public MyPlayer(Player player)
        {
            this.player = player;            
        }


        public int getSpeed()
        {
            return speed;
        }

        public int getAngle()
        {
            return angle;
        }

        public double getMod()
        {
            return mod;
        }


        public void KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                isUpPressed = true;
                setMoveAlgorithm(new MoveFaster());

            }
            else if (e.KeyCode == Keys.Down)
            {
                isDownPressed = true;
                setMoveAlgorithm(new MoveSlower());


            }
            else if (e.KeyCode == Keys.Left)
            {
                isLeftPressed = true;
                setMoveAlgorithm(new MoveTurn(isLeftPressed, isRightPressed));


            }
            else if (e.KeyCode == Keys.Right)
            {
                isRightPressed = true;
                setMoveAlgorithm(new MoveTurn(isLeftPressed, isRightPressed));



            }
            else if (e.KeyCode == Keys.Space)
            {
                setMoveAlgorithm(new MoveStop());
            }
        }

        public void KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                isUpPressed = false;
                setMoveAlgorithm(new MoveStop());


            }
            else if (e.KeyCode == Keys.Down)
            {
                isDownPressed = false;
                setMoveAlgorithm(new MoveStop());

            }
            else if (e.KeyCode == Keys.Left)
            {
                isLeftPressed = false;

                //after turning setting move algorithm to previous
                if (mod > 0.01)
                {
                    setMoveAlgorithm(new MoveFaster());
                }
                else if (mod == 0)
                {
                    setMoveAlgorithm(new MoveStop());
                }
                else if (mod < -0.01)
                {
                    setMoveAlgorithm(new MoveSlower());
                }

                if (!isUpPressed && !isDownPressed)
                {
                    setMoveAlgorithm(new MoveStop());
                }

            }
            else if (e.KeyCode == Keys.Right)
            {
                isRightPressed = false;

                //after turning setting move algorithm to previous
                if (mod > 0.01)
                {
                    setMoveAlgorithm(new MoveFaster());
                }
                else if (mod == 0)
                {
                    setMoveAlgorithm(new MoveStop());
                }
                else if (mod < -0.01)
                {
                    setMoveAlgorithm(new MoveSlower());
                }

                if (!isUpPressed && !isDownPressed)
                {
                    setMoveAlgorithm(new MoveStop());
                }
            }
            else if (e.KeyCode == Keys.Space)
            {
                if (isUpPressed)
                {
                    setMoveAlgorithm(new MoveFaster());
                }
                else if (isDownPressed)
                {
                    setMoveAlgorithm(new MoveSlower());
                }
            }

            /*if(e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                mod = 0;
            }*/

        }


        private void setMoveAlgorithm(MoveAlgorithm algorithm)
        {
            player.setMoveAlgorithm(algorithm);
        }


        public void Move()
        {            
            player.Move();
        }
    }
}
