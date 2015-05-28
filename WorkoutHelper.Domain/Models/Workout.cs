using System;
using System.Collections.Generic;
using WorkoutHelper.Domain.Enums;

namespace WorkoutHelper.Domain.Models
{
	public class Workout
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public bool PersonalRecord { get; set; }

		public string UserName { get; set; }

		public DateTime WorkoutDate { get; set; }

		public DateTime? WorkoutStart { get; set; }

		public DateTime? WorkoutEnd { get; set; }

		//public Feeling WorkoutFeeling { get; set; }

		//public Weather WorkoutWeather { get; set; }
		public int ExerciseProgramId { get; set; }

		//public List<int> ProgramElemenIdts { get; set; }
	}
}