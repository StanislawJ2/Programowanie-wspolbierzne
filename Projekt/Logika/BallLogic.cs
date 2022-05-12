using System.ComponentModel;
using System.Runtime.CompilerServices;
using Dane;

namespace Logika
{
    public class BallLogic : INotifyPropertyChanged
    {
        private readonly Ball ball;


        public BallLogic(Ball ball)
        {
            this.ball = ball;
        }

        public double Speed_X
        {
            get => ball.Speed_x;
            set => ball.Speed_x = value;
        }

        public double Speed_Y
        {
            get => ball.Speed_y;
            set => ball.Speed_y = value;
        }

        public int Size
        {
            get => ball.Size;
            set
            {
                ball.Size = value;
                RaisePropertyChanged("Size_ball");
            }
        }

        public double X_pozycja
        {
            get => ball.X_pozycja;
            set
            {
                ball.X_pozycja = value;
                RaisePropertyChanged("X_pozycja");
            }
        }
        public double Y_pozycja
        {
            get => ball.Y_pozycja;
            set
            {
                ball.Y_pozycja = value;
                RaisePropertyChanged("Y_pozycja");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
