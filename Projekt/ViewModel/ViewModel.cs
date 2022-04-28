using System;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace Prezentacja.ViewModel
{
    public class ViewModelClass : ViewModelBase
    {


        private int ballNr = 1;

        public ViewModelClass()
        {
        }

        public string BallNr
        {
            get => Convert.ToString(ballNr);
            set
            {
                Regex regex = new Regex("^([0-9]{1,9})$");
                if (regex.IsMatch(value))
                {
                    ballNr = Convert.ToInt32(value);
                    RaisePropertyChanged("BallNr");
                }
            }
        }
    }
}
