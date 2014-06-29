using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frog_SimpleConsoleGame.Classes
{
    public abstract class Car : MovingObject
    {
        //Car size
        private int sizeX;
        private int sizeY;

        public int SizeX
        {
            get { return sizeX; }
            set
            {
                if (this.sizeX < 0)
                {
                    throw new ArgumentException("SizeX number must be positive!");
                }
                else
                {
                    this.sizeX = value;
                }
            }
        }

        public int SizeY
        {
            get { return sizeY; }
            set
            {
                if (this.sizeY < 0)
                {
                    throw new ArgumentException("sizeY number must be positive!");
                }
                else
                {
                    this.sizeY = value;
                }
            }
        }


        public Car(int row, int coll)
            : base(row, coll)
        { }

    }
}
