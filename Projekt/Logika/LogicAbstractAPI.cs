using System;
using Dane;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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
        public abstract List<BallLogic> getBalls();

        internal sealed class LogicAPI: LogicAbstractAPI
        {
            private DataAbstractAPI dataAPI;
            private List<BallLogic> balls = new List<BallLogic>();
            private List<Ball> dballs = new List<Ball>();
            bool active = false;
            public List<BallLogic> Balls { get => balls; set => balls = value; }
            public bool Active { get => active; set => active = value; }

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
                object balanceLock = new object();
                dataAPI.createZone(zone_x, zone_y, ball_number);
                foreach (Ball b in dataAPI.getBalls())
                {
                    this.Balls.Add(new BallLogic(b));
                    this.dballs.Add(b);
                }
                this.Active = true;
                Logger logger = new Logger(dballs);
                foreach (BallLogic b in this.Balls)
                {
                    Task t = new Task(() =>
                     {
                        double dx, dy, d, vx1, vx2, vy1, vy2;
                        Random random = new Random();
                        while(b.Speed_X + b.Speed_Y == 0)
                        {
                            b.Speed_X = random.Next(-1, 2) * random.NextDouble();
                            b.Speed_Y = random.Next(-1, 2) * random.NextDouble();
                        }
                        while (this.Active)
                        {
                            foreach (BallLogic ball in this.Balls)
                            {
                                if (!ball.Equals(b))
                                {
                                     lock (balanceLock)
                                     {
                                         dx = b.X_pozycja - ball.X_pozycja;
                                         dy = b.Y_pozycja - ball.Y_pozycja;
                                         d = Math.Sqrt(dx * dx + dy * dy);
                                         if (d < ((b.Size / 2) + (ball.Size / 2)))
                                         {
                                             vx1 = b.Speed_X;
                                             vx2 = ball.Speed_X;
                                             vy1 = b.Speed_Y;
                                             vy2 = ball.Speed_Y;
                                             b.Speed_X = ((vx1 * (b.Size - ball.Size)) + (2 * ball.Size * vx2)) / (b.Size + ball.Size);
                                             ball.Speed_X = ((vx2 * (ball.Size - b.Size)) + (2 * b.Size * vx1)) / (b.Size + ball.Size);
                                             b.Speed_Y = ((vy1 * (b.Size - ball.Size)) + (2 * ball.Size * vy2)) / (b.Size + ball.Size);
                                             ball.Speed_Y = ((vy2 * (ball.Size - b.Size)) + (2 * b.Size * vy1)) / (b.Size + ball.Size);
                                         }

                                     }
                                 } 
                            }
                             lock (balanceLock)
                             {
                                 if (b.X_pozycja + (b.Size / 2) + b.Speed_X > zone_x)
                                 {
                                     b.Speed_X = -b.Speed_X;
                                 }
                                 if (b.X_pozycja - (b.Size / 2) + b.Speed_X < 0)
                                 {
                                     b.Speed_X = -b.Speed_X;
                                 }
                                 if (b.Y_pozycja + (b.Size / 2) + b.Speed_Y > zone_y)
                                 {
                                     b.Speed_Y = -b.Speed_Y;
                                 }
                                 if (b.Y_pozycja - (b.Size / 2) + b.Speed_Y < 0)
                                 {
                                     b.Speed_Y = -b.Speed_Y;
                                 }
                                 b.X_pozycja = b.X_pozycja + b.Speed_X;
                                 b.Y_pozycja = b.Y_pozycja + b.Speed_Y;
                             }
                            Thread.Sleep(5);

                        }
                    });
                    t.Start();
                }
            }
            public override List<BallLogic> getBalls()
            {
                return this.Balls;
            }
            public override void stop()
            {
                this.Active = false;
                this.Balls.Clear();
            }
        }
            
    }

}
