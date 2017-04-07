using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace HighlightDatePickerDemo
{
    public class HighlightedDateDescriptionConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 2 || !(values[0] is DateTime) || !(values[1] is IEnumerable<HighlightedDate>))
                return false;

            var date = (DateTime)values[0];
            var dateList = (IEnumerable<HighlightedDate>)values[1];

            var highlightedDate = dateList.FirstOrDefault(hd => hd.Date.Equals(date));

            return highlightedDate != null ? highlightedDate.Description : string.Empty;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}