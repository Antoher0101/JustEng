using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using JustEng.JustEngDAL.Entities;

namespace JustEng.Views.UserControls
{
	/// <summary>
	/// Логика взаимодействия для LibrariesControl.xaml
	/// </summary>
	public partial class LibrariesControl : UserControl
	{
		public LibrariesControl()
		{
			InitializeComponent();
		}

		#region LibrariesSource : Library[] - Массив типа Library

		/// <summary>Массив типа Library</summary>
		public static readonly DependencyProperty LibrariesSourceProperty =
			DependencyProperty.Register(
				nameof(LibrariesSource),
				typeof(Library[]),
				typeof(LibrariesControl),
				new PropertyMetadata(default(Library[])));

		/// <summary>Массив типа Library</summary>
		//[Category("")]
		[Description("Массив типа Library")]
		public Library[] LibrariesSource { get => (Library[])GetValue(LibrariesSourceProperty); set => SetValue(LibrariesSourceProperty, value); }

		#endregion
	}
}
