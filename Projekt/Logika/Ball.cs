using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Logika
{
    public class Ball : INotifyPropertyChanged
    {
        private int x;
        private int y;

        internal Ball(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X_pozycja
        {
            get => x;
            set
            {
                x = value;
                RaisePropertyChanged("X_pozycja");
            }
        }
        public int Y_pozycja
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
