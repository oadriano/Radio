using System;
using System.Globalization;
using System.Windows.Data;

namespace Radio.Converters
{
    internal class VolumeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double volume)
            {
                return volume / 100.0;
            }
            throw new InvalidCastException("Expected value to be of type double.");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double volume)
            {
                return volume * 100;
            }
            throw new InvalidCastException("Expected value to be of type double.");
        }
    }
}