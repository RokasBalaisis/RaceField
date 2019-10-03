﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WebsocketClient
{
    public class Player
    {
        public int id;
        public TransparentCar car;

        public Point position;
        public int speed;
        public int angle;
        public int mod;

        private MoveAlgorithm moveAlgorithm;
        
        public Player(int id, Point position)
        {
            this.id = id;
            this.position = position;
            car = new TransparentCar();
            car.Location = position;
            car.Invalidate();
        }

        private void setMoveAlgorithm (MoveAlgorithm algorithm)
        {
            this.moveAlgorithm = algorithm;
        }

        public void Move()
        {
            // TODO: apply conditions to if's

            //if()
            //{
            //    setMoveAlgorithm(new MoveSlow());
            //}
            //else if ()
            //{
            //    setMoveAlgorithm(new MoveFast());
            //}
            //else if ()
            //{
            //    setMoveAlgorithm(new MoveSideways());
            //}
            //else if ()
            //{
            //    setMoveAlgorithm(new MoveStop());
            //}

            moveAlgorithm.Move();
        }

    }
}
