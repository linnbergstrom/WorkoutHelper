using System;
using System.Collections.Generic;
using System.Linq;
using WorkoutHelper.Domain.Data;
using WorkoutHelper.Domain.Models;

namespace WorkoutHelper.Controllers
{
	public class ExerciseService
	{
		private readonly WorkoutHelperContext db = new WorkoutHelperContext();
		public List<Exercise> GetExercises()
		{
			return db.Exercises.ToList();
		}


		//public Exercise GetById(int id)
		//{
		//	return db.Exercises.First(i => i.Id == id);
		//}

		public void Save(Exercise exercise)
		{
			db.Exercises.Add(exercise);
			db.SaveChanges();
		}

		public Exercise GetById(int id)
		{
			return db.Exercises.First(e => e.Id == id);
		}

		public void Update(Exercise exercise)
		{
			var old = db.Exercises.First(e => e.Id == exercise.Id);
			old = exercise;
			db.SaveChanges();
		}

		public void Delete(int id)
		{
			var exercise = GetById(id);
			db.Exercises.Remove(exercise);
			db.SaveChanges();
		}
	}
}
