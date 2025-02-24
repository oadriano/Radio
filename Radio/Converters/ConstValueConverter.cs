using Radio.Model;
using System.Globalization;
using System.Windows.Data;

namespace Radio.Converters
{
    public class ConstValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null)
            {
                switch (parameter.ToString())
                {
                    case "MINFREQUENCY":
                        return ConstValues.MINFREQUENCY;
                    case "MAXFREQUENCY":
                        return ConstValues.MAXFREQUENCY;
                    default:
                        throw new ArgumentException("Invalid parameter");
                }
            }
            throw new ArgumentException("Parameter cannot be null");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
