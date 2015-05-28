using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using WorkoutHelper.Domain.Enums;
using WorkoutHelper.Domain.Models;

namespace WorkoutHelper.ViewModels
{
	public class ExerciseProgramViewModel
	{
		public int Id { get; set; }
		public string CreatedBy { get; set; }

		[Required]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
		public string Title { get; set; }
		public WkCategory Category { get; set; }

		[Display(Name = "Skill Level")]
		public WkLevel Level { get; set; }

		public bool Public { get; set; }

		//public List<int> ProgramElementIds { get; set; }

		//admin only
		public bool PublicApproved { get; set; }

	}
}