using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WorkoutHelper.Domain.Enums;
using WorkoutHelper.Domain.Models;
using WorkoutHelper.Domain.Services;

namespace WorkoutHelper.ViewModels
{
	public class WorkoutViewModel
	{
		public int Id { get; set; }
		public string Title { get; set; }
		//public bool PersonalRecord { get; set; }
		//public string UserName{ get; set; }

		[DataType(DataType.Date)]
		[Display(Name = "Workout Date")]
		[Required]
		public DateTime WorkoutDate { get; set; }

		[DataType(DataType.Time)]
		[Display(Name = "Start At")]
		public DateTime? WorkoutStart { get; set; }

		[DataType(DataType.Time)]
		[Display(Name = "End At")]
		public DateTime? WorkoutEnd { get; set; }

		[Display(Name = "Exercise Program")]
		[Required]
		public int ExerciseProgramId { get; set; }

		public IEnumerable<System.Web.Mvc.SelectListItem> ExerciseProgramOptions { get; set; }

		public List<ExerciseElementViewModel> ExerciseElements { get; set; }

	}
}