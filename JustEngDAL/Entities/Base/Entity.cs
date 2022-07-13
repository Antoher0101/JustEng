using System.ComponentModel.DataAnnotations;
using JustEng.JustEngInterfaces;

namespace JustEng.JustEngDAL.Entities.Base
{
	public class Entity : IEntity
	{
		[Key]
		public int Id { get; set; }
	}
}
