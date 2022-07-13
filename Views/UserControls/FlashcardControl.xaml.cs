using JustEng.JustEngDAL.Entities;

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace JustEng.Views.UserControls
{
	public partial class FlashcardControl : UserControl
	{
		public FlashcardControl()
		{
			InitializeComponent();
		}

		#region FlashcardSource : Flashcard - Элемент типа Flashcard

		/// <summary>Элемент типа Flashcard</summary>
		public static readonly DependencyProperty FlashcardSourceProperty =
			DependencyProperty.Register(nameof(FlashcardSource), typeof(Flashcard), typeof(FlashcardControl), new FrameworkPropertyMetadata(
				defaultValue:default(Flashcard),
				propertyChangedCallback: OnFlashcardChangedChallback));

		/// <summary>Элемент типа Flashcard</summary>
		//[Category("")]
		[Description("Элемент типа Flashcard")]
		public Flashcard FlashcardSource
		{
			get => (Flashcard)GetValue(FlashcardSourceProperty); 
			set => SetValue(FlashcardSourceProperty, value);
		}

		private static void OnFlashcardChangedChallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		}

		#endregion
	}
}
