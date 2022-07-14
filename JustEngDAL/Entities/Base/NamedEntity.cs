using System.ComponentModel.DataAnnotations;

namespace JustEng.JustEngDAL.Entities.Base
{
	public class NamedEntity : Entity
	{
		[Required]
		public string Name { get; set; }
	}
}
