using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Dane
{
    public class Ball : INotifyPropertyChanged
    {
        private double x;
        private double y;
        private int size;
        private double speed_x;
        private double speed_y;

        public Ball(int size, int x, int y)
        {
            this.x = x;
            this.y = y;
            this.size = size;
        }

        public double Speed_x
        {
            get => speed_x;
            set => speed_x = value;
        }

        public double Speed_y
        {
            get => speed_y;
            set => speed_y = value;
        }


        public int Size
        {
            get => size;
            set
            {
                size = value;
                RaisePropertyChanged("Size_ball");
            }  
        }


        public double X_pozycja
        {
            get => x;
            set
            {
                x = value;
                RaisePropertyChanged("X_pozycja");
            }
        }
        public double Y_pozycja
        {
            get => y;
            set
            {
                y = value;
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
