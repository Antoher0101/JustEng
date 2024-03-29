﻿using JustEng.Infrastructure.Commands;
using JustEng.JustEngDAL.Entities;
using JustEng.JustEngInterfaces;
using JustEng.ViewModels.Base;

using System;
using System.Linq;
using System.Windows.Input;

namespace JustEng.ViewModels
{
	public partial class FlashcardPageViewModel : BaseViewModel
	{
		private IRepository<Flashcard> _flashcardRepository { get; set; }

		#region Notifable properties

		private Flashcard[] _Flashcards;
		public Flashcard[] Flashcards
		{
			get => _Flashcards;
			set => Set(ref _Flashcards, value);
		}

		private Flashcard _currentFlashcard;
		public Flashcard CurrentFlashcard
		{
			get => _currentFlashcard;
			set => Set(ref _currentFlashcard, value);
		}

		private int _currentFlashcardNumber;
		/// <summary>
		/// This value should always be one more then a actual flashcard index in the Flashcard[] array.
		/// </summary>
		public int CurrentFlashcardNumber
		{
			get => _currentFlashcardNumber;
			set
			{
				Set(ref _currentFlashcardNumber, value);
				OnCurrentFlashcardNumberChanged(in _currentFlashcardNumber);
			}
		}

		private int _totalFlashcards;
		public int TotalFlashcards
		{
			get => _totalFlashcards; 
			set => Set(ref _totalFlashcards, value);
		}

		#endregion

		#region Other Events
		private void OnCurrentFlashcardNumberChanged(in int value)
		{
			if(value < 0 || value > TotalFlashcards) throw new ArgumentOutOfRangeException(nameof(CurrentFlashcardNumber) + "value is out of the range.");
			CurrentFlashcard = _Flashcards[value-1];
		} 
		#endregion

		#region commands


		private ICommand _AnyCommand;
		public ICommand AnyCommand => _AnyCommand
			  ??= new RelayCommand(OnAnyCommandExecuted, CanAnyCommandExecute);

		private bool CanAnyCommandExecute(object p) => true;
		private void OnAnyCommandExecuted(object p) { }

		#region Command NextFlashcardCommand - Следующая карточка

		private ICommand _NextFlashcardCommand;

		public ICommand NextFlashcardCommand => _NextFlashcardCommand
			??= new RelayCommand(OnNextFlashcardCommandExecuted, CanNextFlashcardCommandExecute);

		/// <summary>Проверка возможности выполнения - Следующая карточка</summary>
		private bool CanNextFlashcardCommandExecute(object p)
		{
			if (CurrentFlashcardNumber >= TotalFlashcards)
			{
				return false;
			}
			return true;
		}

		/// <summary>Логика выполнения - Следующая карточка</summary>
		private void OnNextFlashcardCommandExecuted(object p)
		{
			CurrentFlashcardNumber++;
		}

		#endregion
		#region Command PrevFlashcardCommand - Предыдущая карточка

		private ICommand _PrevFlashcardCommand;

		public ICommand PrevFlashcardCommand => _PrevFlashcardCommand
			??= new RelayCommand(OnPrevFlashcardCommandExecuted, CanPrevFlashcardCommandExecute);

		/// <summary>Проверка возможности выполнения - Предыдущая карточка</summary>
		private bool CanPrevFlashcardCommandExecute(object p)
		{
			if (CurrentFlashcardNumber <= 1)
			{
				return false;
			}
			return true;
		}

		/// <summary>Логика выполнения - Предыдущая карточка</summary>
		private void OnPrevFlashcardCommandExecuted(object p)
		{
			CurrentFlashcardNumber--;
		}

		#endregion
		#endregion

		public FlashcardPageViewModel(IRepository<Flashcard> flashcardRepository)
		{
			_flashcardRepository = flashcardRepository;
			Flashcards = _flashcardRepository.Items.ToArray();
			TotalFlashcards = Flashcards.Length;
			CurrentFlashcardNumber = 1;
		}
	}
}