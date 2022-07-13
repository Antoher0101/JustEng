using System.Windows.Controls;
using System.Windows.Input;

namespace JustEng.Views.Pages
{
	/// <summary>
	/// Логика взаимодействия для TensePage.xaml
	/// </summary>
	public partial class TensePage : Page
	{
		public TensePage()
		{
			InitializeComponent();
		}

		// temporary solution
		private void DataGrid_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
		{
			ScrollViewer.ScrollToVerticalOffset(ScrollViewer.VerticalOffset - e.Delta);
		}
	}
}
