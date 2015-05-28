using System;
using System.Collections.Generic;
using System.Linq;
using WorkoutHelper.Domain.Data;
using WorkoutHelper.Domain.Models;

namespace WorkoutHelper.Domain.Services
{
	public class ExerciseProgramService
	{
		private readonly WorkoutHelperContext db = new WorkoutHelperContext();

		public List<ExerciseProgram> GetAll()
		{
			return db.ExercisePrograms.ToList();
		}

		public int Save(ExerciseProgram model)
		{
			//var programs = db.ExercisePrograms.Where(c => c.Public == true);
			var programs = db.ExercisePrograms.Where(w => w.Title == model.Title);
			var byUserExists = programs.Any(w => w.CreatedBy == model.CreatedBy);
			if (byUserExists)
			{
				return -1;
			}

			db.ExercisePrograms.Add(model);
			db.SaveChanges();

			return model.Id;
		}

		public List<ExerciseProgram> GetPublicPrograms()
		{
			return db.ExercisePrograms.Where(e => e.PublicApproved ==true).ToList();
		}

		public ExerciseProgram GetById(int id)
		{
			return db.ExercisePrograms.First(i => i.Id == id);
		}

		public int ValidateName(ExerciseProgram program)
		{
			var programs = db.ExercisePrograms.Where(c => c.Public == true);
			var exists = programs.Any(w => w.Title == program.Title);
			if (exists)
			{
				return -1;
			}


			return program.Id;
		}

		public List<ExerciseProgram> GetMyPrograms(string user)
		{
			return  db.ExercisePrograms.Where(c => c.CreatedBy == user).ToList();
		}

		public void DeleteEP(int id)
		{
			var prog = GetById(id);
			db.ExercisePrograms.Remove(prog);
			db.SaveChanges();
		}

		public void Update(ExerciseProgram program)
		{
			ExerciseProgram old = db.ExercisePrograms.First(w => w.Id == program.Id);
			db.SaveChanges();
		}
	}
}