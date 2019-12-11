using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using WebsocketClient.Bridge;
using WebsocketClient.State;

namespace WebsocketClient
{
    public class Player: IterableViewObject
    {
        public int id;
        public TransparentCar car;

        public Point position;
        public int speed;
        public int angle;
        public int mod;
        public Color color;

        private MoveAlgorithm moveAlgorithm;

        private MoveStateContext stateContext; 

        public Player(int id)
        {
            this.id = id;
            //this.position = position; 
            stateContext = new MoveStateContext();
        }

        public void initializeCar()
        {
            car = new TransparentCar();
            car.Location = position;
        }

        public void setMoveAlgorithm (MoveAlgorithm algorithm)
        {
            this.moveAlgorithm = algorithm;
        }

        public void setImplementor(Iimplementor implementor)
        {
            this.moveAlgorithm.mode = implementor;
        }


        public void setState(String state)
        {
            if(state == "Faster")
            {
                stateContext.SetState(new MoveFasterState());
            }
            else if(state == "Slower")
            {
                stateContext.SetState(new MoveSlowerState());
            }
            else if(state == "Stop")
            {
                stateContext.SetState(new MoveStopState());
            }            
        }

        public void setTurnState(bool isLeftPressed, bool isRightPressed, bool isDownPressed)
        {
            stateContext.SetState(new MoveTurnState(isLeftPressed, isRightPressed, isDownPressed));
        }

        public void Move()
        {
            //moveAlgorithm.Move();
            stateContext.Move();

        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        public override bool Equals(object obj)
        {

            return id.Equals(((Player)obj).id);
        }

        public void SetRatio(double ratio)
        {
            //throw new NotImplementedException();
        }
    }
}
