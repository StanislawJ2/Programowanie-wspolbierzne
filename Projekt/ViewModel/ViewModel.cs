using System;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using Model;

namespace Prezentacja.ViewModel
{
    public class ViewModelClass : INotifyPropertyChanged
    {
        public ViewModelClass(ModelAbstractAPI modelAPI = null)
        {
            StartCommand = new RelayCommand(start);
            StopCommand = new RelayCommand(stop);
            if (modelAPI == null)
            {
                this.modelAPI = ModelAbstractAPI.createAPI();
            }
            else
            {
                this.modelAPI = modelAPI;
            }
        }
        public ViewModelClass() : this(null) { }
        private ModelAbstractAPI modelAPI;
        private int ballNr = 1;
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
        public ICommand StartCommand { get; set; }
        public ICommand StopCommand { get; set; }
        private ObservableCollection<Ball_Presentation> balllist;
        public ObservableCollection<Ball_Presentation> Balllist
        {
            get => balllist;
            set
            {
                if (value.Equals(balllist)) { return; }
                balllist = value;
                RaisePropertyChanged("Balllist");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool startEnable = true;
        public bool StartEnable
        {
            get => startEnable;
            set
            {
                startEnable = value;
                RaisePropertyChanged("StartEnable");
                RaisePropertyChanged("StopEnable");
            }
        }
        public bool StopEnable
        {
            get => !startEnable;
        }
        private void start()
        {
            try
            {
                modelAPI.createZone(ballNr);
            }
            catch (System.ArgumentException)
            {
                return;
            }
            StartEnable = false;
            Balllist = modelAPI.GetBall_Presentations();
        }
        private void stop()
        {
            modelAPI.stop();
            StartEnable = true;
        }
    }
}
