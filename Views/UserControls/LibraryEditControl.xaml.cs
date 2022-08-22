using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Converters;
using JustEng.Infrastructure.Commands;
using JustEng.JustEngDAL.Entities;

namespace JustEng.Views.UserControls
{
	/// <summary>
	/// Interaction logic for LibraryEditPage.xaml
	/// </summary>
	public partial class LibraryEditControl : UserControl
	{
		public bool EditingMode { get; set; }
		private Button last_btn;
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

		#region DeleteCommand : ICommand - Binding delete command

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

		#region ApplyNewCommand : ICommand

		/// <summary></summary>
		public static readonly DependencyProperty ApplyNewCommandProperty =
			DependencyProperty.Register(
				nameof(ApplyNewCommand),
				typeof(ICommand),
				typeof(LibraryEditControl),
				new PropertyMetadata(default(ICommand)));

		/// <summary></summary>
		//[Category("")]
		[Description("")]
		public ICommand ApplyNewCommand { get => (ICommand)GetValue(ApplyNewCommandProperty); set => SetValue(ApplyNewCommandProperty, value); }

		#endregion

		private void EditCardButton_OnClick(object Sender, RoutedEventArgs E)
		{
			last_btn = ((Button)Sender);
			last_btn.Visibility = Visibility.Collapsed;
			EditingMode = false;
		}

		private void ApplyEditCardButton_OnClick(object Sender, RoutedEventArgs E)
		{
			last_btn.Visibility = Visibility.Visible;
			EditingMode = true;
			ApplyNewCommand.Execute(((Button)Sender).Tag);
		}
	}
}
