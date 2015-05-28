using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkoutHelper.Domain.Models;
using WorkoutHelper.ViewModels;

namespace WorkoutHelper.Controllers
{
	[Authorize]
    public class ExerciseController : Controller
    {
		private readonly ExerciseService _exerciseService;

		public ExerciseController()
		{
			_exerciseService = new ExerciseService();
		}

        // GET: Exercise/Details/5
        public ActionResult Details(int id)
        {
			Exercise exercise = _exerciseService.GetById(id);
            return View(exercise);
        }

        // GET: Exercise/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Exercise/Create
        [HttpPost]
        public ActionResult Create(ExerciseViewModel model)
        {
            try
            {
				Exercise exercise = new Exercise
			{
				Title = model.Title,
				ExerciseType = model.ExerciseType,
				Force = model.Force,
				Level = model.Level,
				MainMuscle = model.MainMuscle,
				Notes = model.Notes,
				Public = model.Public
			};			
				_exerciseService.Save(exercise);
                return RedirectToAction("Index", "Admin");
            }
            catch
            {
                return View();
            }
        }

        // GET: Exercise/Edit/5
        public ActionResult Edit(int id)
        {
			Exercise exercise = _exerciseService.GetById(id);

			ExerciseViewModel model = new ExerciseViewModel
			{
				Title = exercise.Title,
				ExerciseType = exercise.ExerciseType,
				Force = exercise.Force,
				Level = exercise.Level,
				MainMuscle = exercise.MainMuscle,
				Notes = exercise.Notes,
				Public = exercise.Public,
				Id = exercise.Id
			};
			return View(model);
        }

        // POST: Exercise/Edit/5
        [HttpPost]
        public ActionResult Edit(ExerciseViewModel model)
        {
			try
			{
				Exercise exercise = _exerciseService.GetById(model.Id);
				
					exercise.Title = model.Title;
					exercise.ExerciseType = model.ExerciseType;
					exercise.Force = model.Force;
					exercise.Level = model.Level;
					exercise.MainMuscle = model.MainMuscle;
					exercise.Notes = model.Notes;
					exercise.Public = model.Public;
				
				_exerciseService.Update(exercise);
				return RedirectToAction("Index", "Admin");
			}
			catch
			{
				return View();
			}
        }

		[HttpPost]
		public ActionResult Delete(int id)
		{
			_exerciseService.Delete(id);
			return RedirectToAction("Index", "Admin");
		}
    }
}
