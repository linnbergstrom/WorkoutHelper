using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorkoutHelper.Domain.Models;

namespace WorkoutHelper.ViewModels
{
	public class AdminViewModel
	{
		//public List<string> Muscles { get; set; }
		public List<Exercise> Exercises { get; set; }
		//public List<AdminApprovedEPog> AdminApprovedEP { get; set; }
		public List<User> Users  { get; set; }
		public List<ExerciseProgram> ApprovedExercisePrograms { get; set; }

		public IEnumerable<ExerciseProgram> EPForApproval { get; set; }
	}
}