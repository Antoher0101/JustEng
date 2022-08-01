using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace JustEng.Views.Pages
{
	/// <summary>
	/// Логика взаимодействия для FlashcardPage.xaml
	/// </summary>
	public partial class FlashcardPage : ContentControl
	{
		private bool flipped;
		public FlashcardPage()
		{
			InitializeComponent();
		}

		private void OnTextUpdated(object? Sender, DataTransferEventArgs E)
		{
			if (flipped)
			{
				(Flipper.FrontContent, Flipper.BackContent) = (Flipper.BackContent, Flipper.FrontContent);
			}
			flipped = false;
		}

		private void Flipper_IsFlippedChanged(object sender, RoutedPropertyChangedEventArgs<bool> e)
		{
			flipped = true;
		}
	}
}
