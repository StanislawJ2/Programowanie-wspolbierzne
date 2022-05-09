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
        private double x;
        private double y;
        private int size;

        internal Ball_Presentation(Ball b)
        {
            this.size = b.Size;
            this.x = b.X_pozycja - (size/2);
            this.y = b.Y_pozycja - (size/2);
            b.PropertyChanged += update;
        }

        private void update(object sender, PropertyChangedEventArgs e)
        {

            Ball ball = (Ball)sender;
            if (e.PropertyName == "X_pozycja")
            {
                this.X = ball.X_pozycja - (size/2);
            }
            else if(e.PropertyName == "Y_pozycja")
            {
                this.Y = ball.Y_pozycja - (size/2);
            }
            else if(e.PropertyName == "Size_ball")
            {
                this.Size = ball.Size;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public int Size
        {
            get => size;
            set
            {
                size = value;
                RaisePropertyChange("Size");
            }
        }
        public double X
        {
            get => x;
            set
            {
                x = value;
                RaisePropertyChange("X");
            }
        }

        public double Y
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
