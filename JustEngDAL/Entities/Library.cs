using System.Collections;
using System.Collections.Generic;
using JustEng.JustEngDAL.Entities.Base;
using Microsoft.Xaml.Behaviors.Core;

namespace JustEng.JustEngDAL.Entities
{
	public class Library : NamedEntity
	{
		public virtual ICollection<Flashcard> Flashcards { get; set; }
	}
}
