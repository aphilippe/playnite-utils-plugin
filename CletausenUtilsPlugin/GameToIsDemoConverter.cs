using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using Playnite.SDK.Models;

namespace CletausenUtilsPlugin
{
    public class CategoriesToIsDemoConverter : IValueConverter
    {
        private Category _demoCategory;

        public CategoriesToIsDemoConverter(Category demoCategory)
        {
            _demoCategory = demoCategory;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var categories = value as List<Category>;
            if (categories == null)
                return false;

            return categories.Contains(_demoCategory);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}