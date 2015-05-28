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
   public class WorkoutRepository : IWorkoutRepository
    {
	    public IQueryable<Workout> GetAll()
	    {
		    throw new NotImplementedException();
	    }

	    public IQueryable<Workout> FindBy(Expression<Func<Workout, bool>> predicate)
	    {
		    throw new NotImplementedException();
	    }

	    public void Add(Workout entity)
	    {
		    throw new NotImplementedException();
	    }

	    public void Delete(Workout entity)
	    {
		    throw new NotImplementedException();
	    }

	    public void Edit(Workout entity)
	    {
		    throw new NotImplementedException();
	    }

	    public void Save()
	    {
		    throw new NotImplementedException();
	    }

	    public Workout GetSingle(int id)
	    {
		    throw new NotImplementedException();
	    }

	    public List<Workout> GetWorkoutsByDate(DateTime date)
	    {
		    throw new NotImplementedException();
	    }
    }
}
