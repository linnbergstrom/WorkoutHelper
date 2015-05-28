using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WorkoutHelper.Domain.Data;
using WorkoutHelper.Domain.Models;

namespace WorkoutHelper.Domain.Services
{
	public class WorkoutService
	{
		private readonly WorkoutHelperContext db = new WorkoutHelperContext();

		public List<Workout> GetByDate(DateTime date)
		{
			var todayStart = DateTime.Now.Date;
			var todayEnd = DateTime.Now.Date.AddDays(1).AddSeconds(-1);
			List<Workout> workouts = db.Workouts.Where(w => w.WorkoutDate >= todayStart && w.WorkoutDate <= todayEnd).ToList();
			return workouts;
		}

		public Workout GetById(int id)
		{
			Workout workout = db.Workouts.FirstOrDefault(w => w.Id == id);
			return workout;
		}

		public List<Workout> GetAllMyWorkouts(string userName)
		{
			return db.Workouts.Where(w =>w.UserName == userName) .ToList();
		}

		public Workout SaveWorkout(Workout model)
		{
			db.Workouts.Add(model);
			db.SaveChanges();
			return model;
		}

		public List<Workout> GetWeeksWorkouts(DateTime startDate, DateTime endDate, string userName)
		{
			var userWorkouts = db.Workouts.Where(w => w.UserName == userName);
			startDate = startDate.Date;
			endDate = endDate.Date.AddDays(1).AddSeconds(-1);
			var workouts = userWorkouts.Where(
				workout => workout.WorkoutDate >= startDate &&
					workout.WorkoutDate <= endDate).ToList();

			return workouts;
		}



		public void Delete(int id)
		{
			var workout = db.Workouts.FirstOrDefault(w => w.Id == id);
			db.Workouts.Remove(workout);
			db.SaveChanges();
		}

		public void UpdateWorkout(Workout workout)
		{
			Workout old = db.Workouts.First(w => w.Id == workout.Id);
			old.Title = workout.Title;
			old.WorkoutDate = workout.WorkoutDate;
			old.WorkoutStart = workout.WorkoutStart;
			old.WorkoutEnd = workout.WorkoutEnd;
			db.SaveChanges();
		}

	}
}