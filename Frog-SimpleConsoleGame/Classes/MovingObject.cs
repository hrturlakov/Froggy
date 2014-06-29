using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frog_SimpleConsoleGame
{
    public abstract class MovingObject
    {
        public MovingObject(int row, int coll)
        {
            this.Row = row;
            this.Coll = coll;
        }

        private int row;
        private int coll;

        public int Row
        {
            get { return this.row; }
            set
            {
                if (this.row < 0 || this.row > MainProgram.MaxHeight)
                {
                    throw new ArgumentException("Wrong row number!");
                }
                else
                {
                    this.row = value;
                }
            }

        }

        public int Coll
        {
            get { return coll; }
            set
            {
                if (this.coll < 0 || this.coll > MainProgram.MaxWidth)
                {
                    throw new ArgumentException("Wrong coll number!");
                }
                else
                {
                    this.coll = value;
                }
            }
        }

        public virtual void Move()
        {
        }

        public virtual void Render()
        {
        }

        public virtual void PrintOnPosition()
        {
        }
    }
}
