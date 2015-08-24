using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkoutHelper.Domain.Models
{
	public class Set
	{
		public int Id { get; set; }

		public int? Reps { get; set; }

		public int? Weight { get; set; }
	}
}