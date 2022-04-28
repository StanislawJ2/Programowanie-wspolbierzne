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
                        while (this.zone.Active)
                        {
                            int speed_x = 0;
                            int speed_y = 0;
                            bool flaga = true;
                            if (flaga)
                            {
                                Random random = new Random();
                                while (speed_x + speed_y == 0)
                                {
                                    speed_x = random.Next(-1, 1);
                                    speed_y = random.Next(-1, 1);
                                }
                                flaga = false;
                            }
                            if (b.X_pozycja + speed_x + 5 > zone_x)
                            {
                                speed_x = -speed_x;
                            }
                            if (b.X_pozycja + speed_x + 5 < 0)
                            {
                                speed_x = -speed_x;
                            }
                            if (b.Y_pozycja - speed_y + 5 > zone_y)
                            {
                                speed_y = -speed_y;
                            }
                            if (b.Y_pozycja + speed_y + 5 < 0)
                            {
                                speed_y = -speed_y;
                            }
                            b.X_pozycja = b.X_pozycja + speed_x;
                            b.Y_pozycja = b.Y_pozycja + speed_y;
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