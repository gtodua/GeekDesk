﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace GeekDesk.Converts
{
    class StringAppendConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            if (parameter == null)
            {
                return value.ToString();
            }
            else
            {
                string val = value.ToString();
                string param = parameter.ToString();
                return param.Replace("{}", val);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
