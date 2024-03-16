using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace WeatherApi
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<WeatherData> _weatherDataList;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            _weatherDataList = new ObservableCollection<WeatherData>();
        }

        private async void GetWeatherButton_Click(object sender, RoutedEventArgs e)
        {
            string weatherLink = "https://www.mgm.gov.tr/FTPDATA/analiz/sonSOA.xml";

            XmlDocument doc = new XmlDocument();
            doc.Load(weatherLink);

            XmlElement root = doc.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("sehirler");

            foreach (XmlNode node in nodes)
            {
                string city = node["ili"].InnerText;
                string status = node["Durum"].InnerText;
                double maximumTemp = double.Parse(node["Mak"].InnerText);
                double minimumTemp = double.Parse(node["Min"].InnerText);

                _weatherDataList.Add(new WeatherData { City = city, Status = status, MaximumTemperature = maximumTemp, MinimumTemperature = minimumTemp });
            }
        }
      
        public ObservableCollection<WeatherData> WeatherData
        {
            get { return _weatherDataList; }
            set { _weatherDataList = value; OnPropertyChanged("WeatherData"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    } }