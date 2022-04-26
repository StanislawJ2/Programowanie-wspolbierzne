using System;
using System.Collections.Generic;
using System.Text;

namespace Logika
{
    internal class Ball
    {
        public Ball()
        {
            Random rnd = new Random();
            this.x = rnd.Next(10, 991);
            this.y = rnd.Next(10, 991);
            while (this.speed_x != 0 || this.speed_y != 0) {
                this.speed_x = (0.01 + rnd.NextDouble()) * rnd.Next(-1, 1);
                this.speed_y = (0.01 + rnd.NextDouble()) * rnd.Next(-1, 1);
            }

            this.size = 10;
        }
        double x;
        double y;
        double speed_x;
        double speed_y;
        readonly double size;

        public double Getx()
        {
            return x;
        }

        public double Gety()
        {
            return y;
        }

        public void BallMovement ()
        {
            if((this.x + this.speed_x) > 1000 -this.size)
            {
                this.x = 1000-this.size;
                this.speed_x = this.speed_x * -1;
                return;
            }
            if ((this.y + this.speed_y) > 1000-this.size)
            {
                this.y = 1000-this.size;
                this.speed_y = this.speed_y * -1;
                return;
            }
            if ((this.x + this.speed_x) < 0 + this.size)
            {
                this.x = 0 + this.size;
                this.speed_x = this.speed_x * -1;
                return;
            }
            if ((this.y + this.speed_y) < 0 + this.size)
            {
                this.y = 0 + this.size;
                this.speed_y = this.speed_y * -1;
                return;
            }
            this.x += this.speed_x;
            this.y += this.speed_y;
            return;
        }

    }
}
