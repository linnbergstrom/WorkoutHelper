using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutHelper.Domain.Models;

namespace WorkoutHelper.Domain.Interfaces
{
	interface IWorkoutProgramRepository : IGenericRepository<WorkoutProgram>
	{
		WorkoutProgram GetSingle(int id);
		WorkoutProgram GetUserWorkoutProgram(string userName);
	}
}
