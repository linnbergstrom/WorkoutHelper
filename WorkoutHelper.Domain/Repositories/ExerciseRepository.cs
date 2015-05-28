using System;
using System.Linq;
using System.Linq.Expressions;
using WorkoutHelper.Domain.Models;

namespace WorkoutHelper.Domain.Interfaces
{
	class ExerciseRepository : IExerciseRepository
	{
		public IQueryable<Exercise> GetAll()
		{
			throw new NotImplementedException();
		}

		public IQueryable<Exercise> FindBy(Expression<Func<Exercise, bool>> predicate)
		{
			throw new NotImplementedException();
		}

		public void Add(Exercise entity)
		{
			throw new NotImplementedException();
		}

		public void Delete(Exercise entity)
		{
			throw new NotImplementedException();
		}

		public void Edit(Exercise entity)
		{
			throw new NotImplementedException();
		}

		public void Save()
		{
			throw new NotImplementedException();
		}

		public Exercise GetSingle(int id)
		{
			throw new NotImplementedException();
		}

		public Exercise GetUsersExercise(string userName)
		{
			throw new NotImplementedException();
		}
	}
}