using System;
using System.Collections.Generic;
using WorkoutHelper.Domain.Models;

namespace WorkoutHelper.Domain.Interfaces
{
	interface IExerciseRepository : IGenericRepository<Exercise>
	{
		Exercise GetSingle(int id);
		Exercise GetUsersExercise(string userName);

    }
}
