using System;
using System.Collections.Generic;
using WorkoutHelper.Domain.Enums;
using WorkoutHelper.Domain.Models;

namespace WorkoutHelper.Domain.Models
{
	public class ExerciseProgram
	{
		public int Id { get; set; }

		public string CreatedBy { get; set; }

		public string Title { get; set; }

		public WkCategory Category { get; set; }

		public WkLevel Level { get; set; }

		public bool Public { get; set; }

		public bool? PublicApproved { get; set; }
	}

}
