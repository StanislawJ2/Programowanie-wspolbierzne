using System;
using System.Collections.Generic;
using System.Text;
using Logika;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Model
{
    public class Ball_Presentation : INotifyPropertyChanged
    {
        private int x;
        private int y;

        internal Ball_Presentation(Ball b)
        {
            this.x = b.X_pozycja - 5;
            this.y = b.Y_pozycja - 5;
            b.PropertyChanged += update;
        }

        private void update(object sender, PropertyChangedEventArgs e)
        {

            Ball ball = (Ball)sender;
            if (e.PropertyName == "X_pozycja")
            {
                this.X = ball.X_pozycja - 5;
            }
            else if(e.PropertyName == "Y_pozycja")
            {
                this.Y = ball.Y_pozycja - 5;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public int X
        {
            get => x;
            set
            {
                x = value;
                RaisePropertyChange("X");
            }
        }

        public int Y
        {
            get => y;
            set
            {
                y = value;
                RaisePropertyChange("Y");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void RaisePropertyChange([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
