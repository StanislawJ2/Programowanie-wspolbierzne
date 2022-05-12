using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dane
{
    public abstract class DataAbstractAPI
    {
        private Zone zone;
        public Zone Zone { get => zone; set => zone = value; }

        abstract public void createZone(int zone_x, int zone_y, int ball_number);
        public abstract List<Ball> getBalls();
        public static DataAbstractAPI createAPI()
        {
            return new DataAPI();
        }

        internal sealed class DataAPI : DataAbstractAPI
        {
            public override void createZone(int zone_x, int zone_y, int ball_number)
            {

                this.Zone = new Zone(zone_x, zone_y, ball_number);
            }
            public override List<Ball> getBalls()
            {
                return Zone.Ball_list;

            }
        }
    }
}
