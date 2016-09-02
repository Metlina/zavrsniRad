using System;
using System.Globalization;
using Xamarin.Forms;

namespace ZavrsniRad
{
    public class IntToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && parameter != null)
            {
                var i = int.Parse(parameter.ToString());

                if ((int)value == i)
                {
                    return (Color)Application.Current.Resources["CorrectAnswerColor"];
                }
                else
                {
                    return (Color)Application.Current.Resources["QuestionLabelColor"];
                }
            }

            return Color.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

