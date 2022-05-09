﻿using System;
using Dane;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Logika
{
    public abstract class LogicAbstractAPI
    {
        public static LogicAbstractAPI createAPI(DataAbstractAPI dataAbstractAPI = null)
        {
            return new LogicAPI(dataAbstractAPI);
        }
        public abstract void stop();
        public abstract void createZone(int zone_x, int zone_y, int ball_number);
        public abstract List<Ball> getBalls();

        internal sealed class LogicAPI: LogicAbstractAPI
        {
            private Zone zone;
            private DataAbstractAPI dataAPI;
            internal LogicAPI(DataAbstractAPI dataAbstractAPI = null)
            {
                if(dataAbstractAPI == null)
                {
                    this.dataAPI = DataAbstractAPI.createAPI();
                }
                else
                {
                    this.dataAPI = dataAbstractAPI;
                }
            }
            public override void createZone(int zone_x, int zone_y, int ball_number)
            {
                this.zone = new Zone(zone_x, zone_y, ball_number);
                foreach (Ball b in zone.Ball_list)
                {
                    Thread t = new Thread(() =>
                     {
                        double dx, dy, d,vx1,vx2,vy1,vy2;
                        Random random = new Random();
                        while(b.speed_X + b.speed_Y == 0)
                        {
                            b.speed_X = random.Next(-1, 2) * random.NextDouble();
                            b.speed_Y = random.Next(-1, 2) * random.NextDouble();
                        }
                        while (this.zone.Active)
                        {
                            foreach (Ball ball in this.zone.Ball_list)
                            {
                                if (!ball.Equals(b))
                                {
                                     dx = b.X_pozycja - ball.X_pozycja;
                                     dy = b.Y_pozycja - ball.Y_pozycja;
                                     d = Math.Sqrt(dx * dx + dy * dy);
                                     if(d <= ((b.Size/2) + (ball.Size/2)))
                                     {
                                         vx1 = b.speed_X;
                                         vx2 = ball.speed_X;
                                         vy1 = b.speed_Y;
                                         vy2 = ball.speed_Y;
                                         b.speed_X = ((vx1 * (b.Size - ball.Size)) + (2 * ball.Size * vx2)) / (b.Size + ball.Size);
                                         ball.speed_X = ((vx2 * (ball.Size - b.Size)) + (2 * b.Size * vx1)) / (b.Size + ball.Size);
                                         b.speed_Y = ((vy1 * (b.Size - ball.Size)) + (2 * ball.Size * vy2)) / (b.Size + ball.Size);
                                         ball.speed_Y = ((vy2 * (ball.Size - b.Size)) + (2 * b.Size * vy1)) / (b.Size + ball.Size);
                                     }
                                } 
                            }
                            if (b.X_pozycja + (b.Size/2) > zone_x)
                            {
                                 b.speed_X = -b.speed_X;
                            }
                            if (b.X_pozycja - (b.Size / 2) < 0)
                            {
                                 b.speed_X = -b.speed_X;
                            }
                            if (b.Y_pozycja + (b.Size / 2) > zone_y)
                            {
                                 b.speed_Y = -b.speed_Y;
                            }
                            if (b.Y_pozycja - (b.Size / 2) < 0)
                            {
                                 b.speed_Y = -b.speed_Y;
                            }
                            b.X_pozycja = b.X_pozycja + b.speed_X;
                            b.Y_pozycja = b.Y_pozycja + b.speed_Y;

                            
                            Thread.Sleep(5);

                        }
                    });
                    t.Start();
                }
            }
            public override List<Ball> getBalls()
            {
                return zone.Ball_list;
            }
            public override void stop()
            {
                this.zone.Active = false;
            }
        }
            
    }

}
