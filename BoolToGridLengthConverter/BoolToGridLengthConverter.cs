using System;
using System.Text.RegularExpressions;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Net.Habashi.Uwp.Converter.BoolToGridLengthConverter
{
    /// <summary>
    /// Converter for Boolean-Values in GridLength Values.
    /// </summary>
    public sealed class BoolToGridLengthConverter : IValueConverter
    {
        /// <summary>
        /// Converts Boolean-Values into GridLength Values.  
        /// </summary>
        /// <param name="value">Boolean value</param>
        /// <param name="targetType">GridLength</param>
        /// <param name="parameter">To convert to GridLength</param>
        /// <param name="language"></param>
        /// <returns>GridLength(0) if value == false, otherwise the converted parameter-value</returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
            {
                throw new ArgumentNullException("bind value");
            }

            if (!(value is bool))
            {
                throw new ArgumentException("bind value must be of type bool");
            }
            var bindValue = (bool)value;

            if (parameter == null)
            {
                throw new ArgumentNullException("parameter value");
            }
            var stringParameter = parameter as string;

            GridLength convertedResult;
            if (bindValue)
            {
                var paramIsAuto = string.Equals(stringParameter, "Auto", StringComparison.OrdinalIgnoreCase);
                if (paramIsAuto)
                {
                    convertedResult = new GridLength(0, GridUnitType.Auto);
                }
                else if (new Regex(@"\d+\*").IsMatch(stringParameter))
                {
                    var digitString = stringParameter.Substring(0, stringParameter.Length - 1);
                    var doubleValueDigitString = System.Convert.ToDouble(digitString);
                    convertedResult = new GridLength(doubleValueDigitString, GridUnitType.Star);
                }
                else if (new Regex(@"\d+").IsMatch(stringParameter))
                {
                    var digitString = stringParameter.Substring(0, stringParameter.Length);
                    var doubleValueDigitString = System.Convert.ToDouble(digitString);
                    convertedResult = new GridLength(doubleValueDigitString, GridUnitType.Pixel);
                }
                else
                {
                    throw new ArgumentException("Invalid value for paramter: " + stringParameter + ". Provide parameter in Auto, Star or Pixel. For more information see the GridLength-Documentation.");
                }
            }
            else
            {
                convertedResult = new GridLength(0);
            }

            return convertedResult;
        }

        /// <summary>
        /// Not implemented and will throw a NotImplementedException.
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
