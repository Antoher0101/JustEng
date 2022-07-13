using JustEng.JustEngDAL.Entities.Base;

using System.ComponentModel.DataAnnotations;

namespace JustEng.JustEngDAL.Entities
{
	public class Flashcard : Entity
	{
		[Required]
		public virtual string Face { get; set; }
		public virtual string Back { get; set; }
		public virtual int? Check { get; set; }
	}
}