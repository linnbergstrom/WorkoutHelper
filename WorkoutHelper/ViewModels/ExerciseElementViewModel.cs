using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using WorkoutHelper.Domain.Models;

namespace WorkoutHelper.ViewModels
{
	public class ExerciseElementViewModel
	{
		public int Id { get; set; }

		[Required]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
		[Display(Name = "Exercise")]
		public string ExerciseName { get; set; }

		public List<Set> Sets { get; set; }

		[Range(0, 1000, ErrorMessage = "{0} can't be negative")]
		public string Note { get; set; }

		//[DataType(DataType.Time)]
		//public DateTime? Time { get; set; }

		//[Range(0, 1000, ErrorMessage = "{0} can't be negative")]
		//[Display(Name = "Distance(km)")]
		//public int? Distance { get; set; }

		public string ParentName { get; set; }

		public string ProgramCategory { get; set; }

		[Display(Name = "Skill Level")]
		public string ProgramLevel { get; set; }

		public int ParentId { get; set; }

		public List<string> ProgramsElementStrings { get; set; }
	}
}