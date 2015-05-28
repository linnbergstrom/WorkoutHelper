using System;
using System.Collections.Generic;
using System.Linq;
using WorkoutHelper.Domain.Data;
using WorkoutHelper.Domain.Models;

namespace WorkoutHelper.Domain.Services
{
	public class ElementService
	{
		private readonly WorkoutHelperContext db = new WorkoutHelperContext();

		public ExerciseElement SaveProgramElement(ExerciseElement element)
		{
			db.ExerciseElements.Add(element);
			db.SaveChanges();
			return element;
		}

		public List<ExerciseElement> GetElements(int id, string parentType)
		{
			return db.ExerciseElements.Where(w => w.ParentId == id && w.ParentType==parentType).ToList();
		}


		public void DeleteEPElements(int progId)
		{
			var elems = db.ExerciseElements.Where(e => e.ParentId == progId);
			foreach (var e in elems)
			{
				db.ExerciseElements.Remove(e);
			}
			db.SaveChanges();
		}

		public void Update(ExerciseElement element)
		{
			ExerciseElement old = db.ExerciseElements.First(w => w.Id == element.Id);
			old.Distance = element.Distance;
			old.Reps = element.Reps;
			old.Sets = element.Sets;
			old.Time = element.Time;
			db.SaveChanges();
		}


		public void DeleteElement(int id, string parentType)
		{
			var elem = db.ExerciseElements.First(e => e.Id == id && e.ParentType == parentType);
			db.ExerciseElements.Remove(elem);
			db.SaveChanges();
		}
	}
}
