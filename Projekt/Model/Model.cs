using Logika;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Model
{
    public abstract class ModelAbstractAPI
    {
        public static ModelAbstractAPI createAPI(LogicAbstractAPI logicAbstractAPI = null)
        {
            return new ModelAPI();
        }

        public abstract void createZone(int number);
        public abstract ObservableCollection<Ball_Presentation> GetBall_Presentations();
        public abstract void stop();
        internal sealed class ModelAPI : ModelAbstractAPI
        {
            internal ModelAPI(LogicAbstractAPI logicAbstractAPI = null)
            {
                if(logicAbstractAPI == null)
                {
                    this.logicAPI = LogicAbstractAPI.createAPI();
                }
                else
                {
                    this.logicAPI = logicAbstractAPI;
                }
            }
            private LogicAbstractAPI logicAPI = LogicAbstractAPI.createAPI(null);
            private ObservableCollection<Ball_Presentation> ball_Presentation = new ObservableCollection<Ball_Presentation>();
            internal ObservableCollection<Ball_Presentation> Ball_Presentations
            {
                get => ball_Presentation;
                set => ball_Presentation = value;
            }
            public override void createZone(int number)
            {
                logicAPI.createZone(780, 319, number);
            }
            public override ObservableCollection<Ball_Presentation> GetBall_Presentations()
            {
                List<Ball> ball_list = logicAPI.getBalls();
                ball_Presentation.Clear();
                foreach(Ball ball in ball_list)
                {
                    ball_Presentation.Add(new Ball_Presentation(ball));
                }
                return ball_Presentation;
            }
            public override void stop()
            {
                logicAPI.stop();
            }

        }
    }
}
