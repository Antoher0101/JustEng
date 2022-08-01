using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Converters;
using JustEng.JustEngDAL.Entities;

namespace JustEng.Views.UserControls
{
	/// <summary>
	/// Interaction logic for LibraryEditPage.xaml
	/// </summary>
	public partial class LibraryEditControl : UserControl
	{
		public LibraryEditControl()
		{
			InitializeComponent();
		}

		#region FlashcardsSource : ICollection<Flashcard> - Source of the flashcards array

		/// <summary>Source of the flashcards array</summary>
		public static readonly DependencyProperty FlashcardsSourceProperty =
			DependencyProperty.Register(
				nameof(FlashcardsSource),
				typeof(ICollection<Flashcard>),
				typeof(LibraryEditControl),
				new PropertyMetadata(default(ICollection<Flashcard>)));

		/// <summary>Source of the flashcards array</summary>
		//[Category("")]
		[Description("Source of the flashcards array")]
		public ICollection<Flashcard> FlashcardsSource { get => (ICollection<Flashcard>)GetValue(FlashcardsSourceProperty); set => SetValue(FlashcardsSourceProperty, value); }
		#endregion

		#region EditingMode : bool - $summary$

		/// <summary>$summary$</summary>
		public static readonly DependencyProperty EditingModeProperty =
			DependencyProperty.Register(
				nameof(EditingMode),
				typeof(bool),
				typeof(LibraryEditControl),
				new PropertyMetadata(default(bool)));

		/// <summary>$summary$</summary>
		//[Category("")]
		[Description("$summary$")]
		public bool EditingMode { get => (bool)GetValue(EditingModeProperty); set => SetValue(EditingModeProperty, value); }

		#endregion

		#region DeleteCommand : ICommand - $summary$

		/// <summary>$summary$</summary>
		public static readonly DependencyProperty DeleteCommandProperty =
			DependencyProperty.Register(
				nameof(DeleteCommand),
				typeof(ICommand),
				typeof(LibraryEditControl),
				new PropertyMetadata(default(ICommand)));

		/// <summary>$summary$</summary>
		//[Category("")]
		[Description("$summary$")]
		public ICommand DeleteCommand { get => (ICommand)GetValue(DeleteCommandProperty); set => SetValue(DeleteCommandProperty, value); }

		#endregion
	}
}
