using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace WeatherApi
{
    public class TemperatureToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || !(value is double))
                return Brushes.Transparent;

            double temperature = (double)value;

            if (temperature < 10)
                return Brushes.LightSkyBlue;
            else if (temperature > 25)
                return Brushes.Red;
            else
                return Brushes.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
