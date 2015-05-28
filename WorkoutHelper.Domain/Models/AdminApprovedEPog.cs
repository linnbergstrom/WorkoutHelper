using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutHelper.Domain.Models
{
	public class AdminApprovedEPog : ExerciseProgram
	{
		public bool PublicApproved { get; set; }
	}
}
