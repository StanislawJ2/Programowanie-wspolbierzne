using System;
using System.Collections.Generic;
using System.Text;

namespace Dane
{
    public class Zone
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
        public int Zone_X => zone_x;
        public int Zone_Y => zone_y;
        public List<Ball> Ball_list => ball_list;
        public void createBall(int ball_number)
        {
            if( zone_x <= 20 || zone_y <= 20 || ball_number <= 0)
            {
                throw new ArgumentOutOfRangeException();
             
            }
            Random rand = new Random();
            for(int i = 0; i < ball_number; i++)
            {
                int size = rand.Next(10, 21);      
                int x = rand.Next(size,this.zone_x - size);
                int y = rand.Next(size,this.zone_y - size);
                this.Ball_list.Add(new Ball(size,x,y,i));
            }
        }
        internal bool Active
        {
            get => active;
            set => active = value;
        }
    }
}
