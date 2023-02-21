using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using CletausenUtilsPlugin.ExtensionClass;
using Playnite.SDK.Models;

namespace CletausenUtilsPlugin
{
    public class GameToIsDemoVisibilityConverter : IValueConverter
    {
        public GameToIsDemoVisibilityConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var game = value as Game;

            if (game == null) return false;
            
            var isDemo = game.IsDemo();
            
            return game.IsDemo() ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}