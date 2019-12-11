using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebsocketClient.Bridge;

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

        private int health = 100;

        public Player player;        

        public MyPlayer(Player player)
        {
            this.player = player;
        }

        public Memento CreateMemento()
        {
            Memento memento = new Memento();
            memento.setState(health, player.position, player.angle, player.mod);
            return memento;
        }

        public void SetMemento(Memento memento)
        {
            Tuple<int, Point, int, int> state = memento.getState();
            health = state.Item1;
            player.position = state.Item2;
            player.angle = state.Item3;
            player.mod = state.Item4;
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
                //setMoveAlgorithm(new MoveFaster());   
                player.setState("Faster");
                

            }
            else if (e.KeyCode == Keys.Down)
            {
                isDownPressed = true;
                //setMoveAlgorithm(new MoveSlower());
                player.setState("Slower");


            }
            else if (e.KeyCode == Keys.Left)
            {
                isLeftPressed = true;
                //setMoveAlgorithm(new MoveTurn(isLeftPressed, isRightPressed, isDownPressed));
                player.setTurnState(isLeftPressed, isRightPressed, isDownPressed);


            }
            else if (e.KeyCode == Keys.Right)
            {
                isRightPressed = true;
                //setMoveAlgorithm(new MoveTurn(isLeftPressed, isRightPressed, isDownPressed));
                player.setTurnState(isLeftPressed, isRightPressed, isDownPressed);



            }
            else if (e.KeyCode == Keys.Space)
            {
                //setMoveAlgorithm(new MoveStop());
                player.setState("Stop");
            }
        }

        public void KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                isUpPressed = false;
                //setMoveAlgorithm(new MoveStop());
                player.setState("Stop");


            }
            else if (e.KeyCode == Keys.Down)
            {
                isDownPressed = false;
                //setMoveAlgorithm(new MoveStop());
                player.setState("Stop");

            }
            else if (e.KeyCode == Keys.Left)
            {
                isLeftPressed = false;

                //after turning setting move algorithm to previous
                if (mod > 0.01)
                {
                    //setMoveAlgorithm(new MoveFaster());
                    player.setState("Faster");
                }
                else if (mod == 0)
                {
                    //setMoveAlgorithm(new MoveStop());
                    player.setState("Stop");
                }
                else if (mod < -0.01)
                {
                    //setMoveAlgorithm(new MoveSlower());
                    player.setState("Slower");
                }

                if (!isUpPressed && !isDownPressed)
                {
                    //setMoveAlgorithm(new MoveStop());
                    player.setState("Stop");
                }

            }
            else if (e.KeyCode == Keys.Right)
            {
                isRightPressed = false;

                //after turning setting move algorithm to previous
                if (mod > 0.01)
                {
                    //setMoveAlgorithm(new MoveFaster());
                    player.setState("Faster");
                }
                else if (mod == 0)
                {
                    //setMoveAlgorithm(new MoveStop());
                    player.setState("Stop");
                }
                else if (mod < -0.01)
                {
                    //setMoveAlgorithm(new MoveSlower());
                    player.setState("Slower");
                }

                if (!isUpPressed && !isDownPressed)
                {
                    //setMoveAlgorithm(new MoveStop());
                    player.setState("Stop");
                }
            }
            else if (e.KeyCode == Keys.Space)
            {
                if (isUpPressed)
                {
                    //setMoveAlgorithm(new MoveFaster());
                    player.setState("Faster");
                }
                else if (isDownPressed)
                {                    
                    //setMoveAlgorithm(new MoveSlower());
                    player.setState("Slower");
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
            player.setImplementor(new BoostedSpeed());
        }
     

        public void Move()
        {            
            player.Move();
        }
    }
}
