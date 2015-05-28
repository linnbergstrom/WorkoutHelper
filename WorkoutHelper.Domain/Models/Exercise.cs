using System.Collections.Generic;
using WorkoutHelper.Domain.Enums;

namespace WorkoutHelper.Domain.Models
{
	public class Exercise
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public WkMuscle MainMuscle { get; set; }

		//public List<WkMuscle> WkMuscles { get; set; }

		public string Notes { get; set; }

		public WkForce Force { get; set; }

		public WkLevel Level { get; set; }

		public WkExerciseType ExerciseType { get; set; }

		public bool Public { get; set; }
	}
}