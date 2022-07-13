
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustEng.Models.Tenses.Base
{
	public abstract class VerbTenses
	{
		public string Name { get; private set; }
		public string Description { get; set; }
		public TenseExample Examples { get; set; }
		public auxiliary Auxiliary { get; set; }
		public VerbTenses(string name)
		{
			Name = name;
		}
		public string Timeline { get; set; }
	}
	public class SimpleTense : VerbTenses
	{
		public SimpleTense() : base("Simple") { }
	}
	public class ContinuousTense : VerbTenses
	{
		public ContinuousTense() : base("Continuous") { }
	}
	public class PerfectTense : VerbTenses
	{
		public PerfectTense() : base("Perfect") { }
	}
	public class PerfectContinuousTense : VerbTenses
	{
		public PerfectContinuousTense() : base("Perfect Continuous") { }
	}
	public struct auxiliary
	{
		public string Positive { get; set; }
		public string Negative { get; set; }
		public string Question { get; set; }
	}

	public struct TenseExample
	{
		public string[] Affirmative { get; set; }
		public string[] Interrogative { get; set; }
		public string[] Negative { get; set; }
	}
}
