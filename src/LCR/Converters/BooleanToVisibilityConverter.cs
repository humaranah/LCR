﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace LCR.Converters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool boolean))
            {
                return Visibility.Collapsed;
            }

            return boolean ? Visibility.Visible : Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Visibility visibility))
            {
                return false;
            }

            return visibility == Visibility.Visible;
        }
    }
}
