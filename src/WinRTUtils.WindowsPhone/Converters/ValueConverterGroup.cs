﻿using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Data;

namespace WinRTUtils.Converters
{
    public class ValueConverterGroup : List<IValueConverter>, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return this.Aggregate(value, (current, converter) => converter.Convert(current, targetType, parameter, language));
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return this.Reverse<IValueConverter>().Aggregate(value, (current, converter) => converter.Convert(current, targetType, parameter, language));
        }
    }
}
