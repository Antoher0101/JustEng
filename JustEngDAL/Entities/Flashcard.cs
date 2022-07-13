using JustEng.JustEngDAL.Entities.Base;

using System.ComponentModel.DataAnnotations;

namespace JustEng.JustEngDAL.Entities
{
	public class Flashcard : Entity
	{
		[Required]
		public string Face { get; set; }
		public string Back { get; set; }
		public int? Check { get; set; }
	}
}