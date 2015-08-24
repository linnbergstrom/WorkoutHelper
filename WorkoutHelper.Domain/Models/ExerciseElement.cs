using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutHelper.Domain.Models
{
	public class ExerciseElement
	{
		public int Id { get; set; }

		public string ExerciseName { get; set; }

		public List<Set> Sets { get; set; }

		public string Note { get; set; }

		public int ParentId { get; set; }

		public string ParentType { get; set; }
	}
}