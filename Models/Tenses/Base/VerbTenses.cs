
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustEng.Models.Tenses.Base
{
	internal abstract class VerbTenses
	{
		public string Name { get; private set; }
		public string Description { get; set; }
		public string[] Examples { get; set; }
		public auxiliary Auxiliary { get; set; }
		public VerbTenses(string name)
		{
			Name = name;
		}
		public string Timeline { get; set; }
	}
	internal class SimpleTense : VerbTenses
	{
		public SimpleTense() : base("Simple") { }
	}
	internal class ContinuousTense : VerbTenses
	{
		public ContinuousTense() : base("Continuous") { }
	}
	internal class PerfectTense : VerbTenses
	{
		public PerfectTense() : base("Perfect") { }
	}
	internal class PerfectContinuousTense : VerbTenses
	{
		public PerfectContinuousTense() : base("Perfect Continuous") { }
	}
	struct auxiliary
	{
		public string positive;
		public string negative;
		public string question;
	}
}
