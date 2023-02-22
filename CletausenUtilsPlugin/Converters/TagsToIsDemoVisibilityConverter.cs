using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace CletausenUtilsPlugin.Converters
{
    public class TagsToIsDemoVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is IEnumerable<Guid> tagIds)) return Visibility.Collapsed;

            return tagIds.Any(x => x == CletausenUtilsPlugin.Instance.Settings.DemoTagId) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}