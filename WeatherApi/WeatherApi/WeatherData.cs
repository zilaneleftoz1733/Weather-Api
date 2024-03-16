using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApi
{
    public class WeatherData : INotifyPropertyChanged
    {
        private string _city;
        private string _status;
        private string _maximum;
        private string _minimum;
        private double _maximumTemperature;
        private double _minimumTemperature;

        public string City
        {
            get { return _city; }
            set { _city = value; OnPropertyChanged("City"); }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged("Status"); }
        }

        public string Maximum
        {
            get { return _maximum; }
            set { _maximum = value; OnPropertyChanged("Maximum"); }
        }

        public string Minimum
        {
            get { return _minimum; }
            set { _minimum = value; OnPropertyChanged("Minimum"); }
        }

        public double MaximumTemperature
        {
            get { return _maximumTemperature; }
            set { _maximumTemperature = value; OnPropertyChanged("MaximumTemperature"); }
        }

        public double MinimumTemperature
        {
            get { return _minimumTemperature; }
            set { _minimumTemperature = value; OnPropertyChanged("MinimumTemperature"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
