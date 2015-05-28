using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WorkoutHelper.Domain.Data;
using WorkoutHelper.Domain.Models;
using WorkoutHelper.Domain.Services;
using WorkoutHelper.ViewModels;

namespace WorkoutHelper.Controllers
{
	 [Authorize]
	public class WorkoutController : Controller
	{
		private readonly ExerciseProgramService _exerciseProgramService;
		private readonly ExerciseService _exerciseService;
		private readonly ElementService _elementService;

		// GET: Workout
		private readonly WorkoutService _workoutService;

		public WorkoutController()
		{
			_workoutService = new WorkoutService();
			_exerciseProgramService = new ExerciseProgramService();
			_exerciseService = new ExerciseService();
			_elementService = new ElementService();
		}

		public WorkoutController(WorkoutService service)
		{
			_workoutService = service;
		}

		public ActionResult Index()
		{
			var list = MenuItem.GetMenu();
			return View(list);
		}

		public ActionResult TodaysWorkouts()
		{
			var workouts = _workoutService.GetByDate(DateTime.Now.Date);
			return View("Workouts", workouts);
		}

		public ActionResult ListWorkouts()
		{
			List<Workout> workouts = _workoutService.GetAllMyWorkouts(User.Identity.Name);
			var sortedWorkouts = workouts.OrderBy(x =>x.WorkoutDate).ToList();
			return View("Workouts", sortedWorkouts);
		}

		//GET: Workout/Details/5
		public ActionResult Details(int id)
		{
			var workout = _workoutService.GetById(id);
			var elems = _elementService.GetElements(id, Constant.ParentIsWorkout) ?? new List<ExerciseElement>();

			List<string> ProgramElements = elems.Select(x => x.ExerciseName).ToList() ?? new List<string>();
			ViewBag.Elements = ProgramElements;
			return View(workout);
		}

		// GET: Workout/Create
		public ActionResult Create()
		{
			List<ExerciseProgram> myPrograms =_exerciseProgramService.GetMyPrograms(User.Identity.Name);
			return View(myPrograms);
		}


		public ActionResult CreateStepTwo(int id)
		{
			var program = _exerciseProgramService.GetById(id);
			List<ExerciseElement> elements = _elementService.GetElements(program.Id, Constant.ParentIsProgram);

			var workout = new WorkoutViewModel();
			workout.Title = program.Title;
			workout.ExerciseProgramId = id;
			workout.WorkoutDate = DateTime.Now.Date.AddHours(DateTime.Now.AddHours(1).Hour);
			return View(workout);
		}

		

		[HttpPost]
		public ActionResult CreateStepTwo(WorkoutViewModel viewModel)
		{
			var model = GenerateWorkout(viewModel);
			var workout =_workoutService.SaveWorkout(model);
			var program = _exerciseProgramService.GetById(model.ExerciseProgramId);
			var progElements = _elementService.GetElements(program.Id, Constant.ParentIsProgram);

			//Save programs element to workout
			foreach (var elem in progElements)
			{
				var we = new ExerciseElement();

				we.ExerciseName = elem.ExerciseName;
				we.Distance = elem.Distance;
				we.Time = elem.Time;
				we.Sets = elem.Sets;
				we.Reps = elem.Reps;
				we.ParentId = workout.Id;
				we.ParentType = Constant.ParentIsWorkout;

				we = _elementService.SaveProgramElement(we);
			}

			return RedirectToAction("ListWorkouts");
		}

		[HttpDelete]
		public ActionResult Delete(int id)
		{
			_workoutService.Delete(id);
			return View("Workouts");
		}

		//Workout/Edit/5
		public ActionResult Edit(int id)
		{
			Workout workout = _workoutService.GetById(id);
			WorkoutViewModel model = GenerateWorkoutViewModel(workout);

			return View("Edit", model);
		}

		public WorkoutViewModel GenerateWorkoutViewModel(Workout workout)
		{
			var elements = _elementService.GetElements(workout.Id, Constant.ParentIsWorkout);
			var ElemViews = new List<ExerciseElementViewModel>();
			//Edit the exercise elements
			foreach (var elem in elements)
			{
				var element = new ExerciseElementViewModel
				{
					Id = elem.Id,
					ExerciseName = elem.ExerciseName,
					ParentId = elem.ParentId,
					Sets = elem.Sets,
					Reps = elem.Reps,
					Distance = elem.Distance,
					Time = elem.Time,
				};
				ElemViews.Add(element);

			}
			ElemViews.Add(new ExerciseElementViewModel());

			WorkoutViewModel model = new WorkoutViewModel
			{
				Id = workout.Id,
				Title = workout.Title,
				WorkoutDate = workout.WorkoutDate,
				WorkoutStart = workout.WorkoutStart,
				WorkoutEnd = workout.WorkoutEnd,
				ExerciseProgramId = workout.ExerciseProgramId,
				ExerciseElements = ElemViews
			};

			return model;
		}

		 [HttpPost]
		 public ActionResult Edit(WorkoutViewModel model)
		{
			Workout workout = GenerateWorkout(model);
			foreach (ExerciseElementViewModel elem in model.ExerciseElements)
			{
				ExerciseElement programElement = new ExerciseElement
				{
					ExerciseName = elem.ExerciseName,
					Id = elem.Id,
					ParentId = elem.ParentId,
					ParentType = Constant.ParentIsWorkout,
					Sets = elem.Sets,
					Reps = elem.Reps,
					Distance = elem.Distance,
					Time = elem.Time,
				};
				_elementService.Update(programElement);
			}
			workout.Id = model.Id;
			_workoutService.UpdateWorkout(workout);
			return View(model);
		}

		 //[HttpPost]
		 //public PartialViewResult AddElement(WorkoutViewModel workout)
		 //{
		 //	var we = new ExerciseElement();
		 //	if (!ModelState.IsValid)
		 //	{
		 //		return PartialView();
		 //	}
		 //	//we.ExerciseName = elem.ExerciseName;
		 //	//we.Distance = elem.Distance;
		 //	//we.Time = elem.Time;
		 //	//we.Sets = elem.Sets;
		 //	//we.Reps = elem.Reps;
		 //	//we.ParentId = elem.ParentId;
		 //	we.ParentType = Constant.ParentIsWorkout;

		 //	we = _elementService.SaveProgramElement(we);
		 //	//Update Workout
		 //	//Add Elements
		 //	//update ViewModel
		 //	//Return new data

		 //	return PartialView();
		 //}

		 [HttpPost]
		 public JsonResult DeleteElement(int id)
		 {
			 _elementService.DeleteElement(id, Constant.ParentIsWorkout);
			 return Json(new { ok = true });
		 }

		 public Workout GenerateWorkout(WorkoutViewModel viewModel)
		 {
			 var model = new Workout
			 {
				 Title = viewModel.Title,
				 WorkoutDate = viewModel.WorkoutDate,
				 WorkoutStart = viewModel.WorkoutStart,
				 WorkoutEnd = viewModel.WorkoutEnd,
				 ExerciseProgramId = viewModel.ExerciseProgramId,
				 UserName = User.Identity.Name
			 };
			 return model;
		 }
	}
}