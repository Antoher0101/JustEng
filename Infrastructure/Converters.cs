﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace JustEng.Infrastructure
{
	public class IntToVisibilityConverter : IValueConverter
	{
		private int val;
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			val = (int)value;

			return (val != 0) ? Visibility.Visible : Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}

	public class InvertVisibility : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (Visibility)value == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}