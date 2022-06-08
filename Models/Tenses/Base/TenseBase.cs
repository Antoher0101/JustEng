using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustEng.Models.Tenses.Base
{
	internal abstract class TenseBase
	{
		public string Name { get; set; }
		public SimpleTense Simple { get; set; }
		public ContinuousTense Continuous { get; set; }
		public PerfectTense Perfect { get; set; }
		public PerfectContinuousTense PerfectContinuous { get; set; }
	}
}
