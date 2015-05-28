using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WorkoutHelper.Domain.Interfaces;
using WorkoutHelper.Domain.Models;

namespace WorkoutHelper.Domain.Repositories
{
	class WorkoutProgramRepository : IWorkoutProgramRepository
	{
		public IQueryable<WorkoutProgram> GetAll()
		{
			throw new NotImplementedException();
		}

		public IQueryable<WorkoutProgram> FindBy(Expression<Func<WorkoutProgram, bool>> predicate)
		{
			throw new NotImplementedException();
		}

		public void Add(WorkoutProgram entity)
		{
			throw new NotImplementedException();
		}

		public void Delete(WorkoutProgram entity)
		{
			throw new NotImplementedException();
		}

		public void Edit(WorkoutProgram entity)
		{
			throw new NotImplementedException();
		}

		public void Save()
		{
			throw new NotImplementedException();
		}

		public WorkoutProgram GetSingle(int id)
		{
			throw new NotImplementedException();
		}

		public WorkoutProgram GetUserWorkoutProgram(string userName)
		{
			throw new NotImplementedException();
		}
	}
}
