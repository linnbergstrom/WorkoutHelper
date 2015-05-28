using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WorkoutHelper.Domain.Enums;
using WorkoutHelper.Domain.Models;

namespace WorkoutHelper.ViewModels
{
	public class ExerciseViewModel
	{
		public int Id { get; set; }

		[Required]
		public string Title { get; set; }
		public string Creator { get; set; }

		[Display(Name = "Main Muscle")]
		public WkMuscle MainMuscle { get; set; }

		//[Display(Name = "Other Muscles")]
		//public List<WkMuscle> WkMuscles { get; set; }

		public string Notes { get; set; }

		[Display(Name = "Force Type")]
		public WkForce Force { get; set; }

		[Display(Name = "Skill Level")]
		public WkLevel Level { get; set; }

		[Display(Name = "Exercise Type")]
		public WkExerciseType ExerciseType { get; set; }

		public bool Public { get; set; }

	}
}