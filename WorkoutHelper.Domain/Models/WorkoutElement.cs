using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutHelper.Domain.Models
{
	class WorkoutElement
	{
		public int Id { get; set; }
		public string ExerciseName { get; set; }

		public int? Sets { get; set; }

		public int? Reps { get; set; }
		public DateTime? Time { get; set; }
		public int? Distance { get; set; }

		public int WorkoutId { get; set; }
	}
}
