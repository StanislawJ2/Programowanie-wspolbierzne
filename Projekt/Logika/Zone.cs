using System;
using System.Collections.Generic;
using System.Text;

namespace Logika
{
    internal class Zone
    {
        private readonly int zone_x;
        private readonly int zone_y;
        private bool active = true;
        private readonly List<Ball> ball_list = new List<Ball>();

        public Zone(int zone_x, int zone_y, int ball_number)
        {
            if(zone_x <= 0 || zone_y <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.zone_x = zone_x;
            this.zone_y = zone_y;

            createBall(ball_number);
        }
        internal int Zone_X => zone_x;
        internal int Zone_Y => zone_y;
        internal List<Ball> Ball_list => ball_list;
        internal void createBall(int ball_number)
        {
            if( zone_x <= 10 || zone_y <= 10 || ball_number <= 0)
            {
                throw new ArgumentOutOfRangeException();
             
            }
            Random rand = new Random();
            for(int i = 0; i < ball_number; i++)
            {
                int x = rand.Next(10,this.zone_x - 10);
                int y = rand.Next(10,this.zone_y - 10);
                this.ball_list.Add(new Ball(x,y));
            }
        }
        internal bool Active
        {
            get => active;
            set => active = value;
        }
    }
}
