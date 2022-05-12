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

        public Ball(int size, int x, int y)
        {
            this.x = x;
            this.y = y;
            this.size = size;
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
