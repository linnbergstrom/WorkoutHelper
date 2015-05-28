using System;
using System.Collections.Generic;
using WorkoutHelper.Domain.Models;

namespace WorkoutHelper.Domain.Interfaces
{
	interface IWorkoutRepository : IGenericRepository<Workout>
	{
		Workout GetSingle(int id);
        List<Workout> GetWorkoutsByDate(DateTime date);

    }
}
