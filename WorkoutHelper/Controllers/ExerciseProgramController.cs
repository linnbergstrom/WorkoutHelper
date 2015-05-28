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
	public class ExerciseProgramController : Controller
	{
		private readonly ExerciseProgramService _exerciseProgramService;
		private readonly ExerciseService _exerciseService;
		private readonly ElementService _elementService;

		public ExerciseProgramController()
		{
			_exerciseProgramService = new ExerciseProgramService();
			_exerciseService = new ExerciseService();
			_elementService = new ElementService();
		}

		// GET: ExerciseProgram
		public ActionResult Index()
		{
			List<ExerciseProgram> programs = _exerciseProgramService.GetMyPrograms(User.Identity.Name);
			return View(programs);
		}

		public ActionResult ListPublicPrograms()
		{
			var publicPrograms = _exerciseProgramService.GetPublicPrograms();
			return View(publicPrograms);
		}

		// GET: ExerciseProgram/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: ExerciseProgram/Create
		[HttpPost]
		public ActionResult Create(ExerciseProgramViewModel model)
		{
			ExerciseProgram program = new ExerciseProgram
			{
				Title = model.Title,
				Category = model.Category,
				Level = model.Level,
				CreatedBy = User.Identity.Name,
				Public = model.Public
			};

			int id = _exerciseProgramService.Save(program);
			if (id == -1)
			{
				ViewBag.SideTitle = "Program already exists";
				ViewBag.SideMessage = "You have a program by this name already";
				return View(model);
			}
			return RedirectToAction("ExerciseElements", new { id });
		}

		public ActionResult ExerciseElements(int id)
		{
			var program = _exerciseProgramService.GetById(id);
			List<ExerciseElement> programElements = _elementService.GetElements(program.Id, Constant.ParentIsProgram);

			var list = new List<string>();
			foreach (var elem in programElements)
			{
				var element = GetElementString(elem);
				list.Add(element);
			}
			var viewModel = new ExerciseElementViewModel
			{
				ParentName = program.Title,
				ParentId = program.Id,
				ProgramCategory = program.Category.ToString(),
				ProgramLevel = program.Level.ToString(),
				ProgramsElementStrings = list				
			};

			return View(viewModel);
		}

		[HttpPost]
		public JsonResult ExerciseElements(ExerciseElementViewModel model)
		{
			if (!ModelState.IsValid)
				return Json(false);

			ExerciseElement programElement = new ExerciseElement
			{
				ExerciseName = model.ExerciseName,
				ParentId = model.ParentId,
				ParentType = Constant.ParentIsProgram,
				Sets = model.Sets,
				Reps = model.Reps,
				Distance = model.Distance,
				Time = model.Time,
			};
			//save
			ExerciseElement element = _elementService.SaveProgramElement(programElement);

			var program = _exerciseProgramService.GetById(element.ParentId);
			List<ExerciseElement> programElements = _elementService.GetElements(program.Id, Constant.ParentIsProgram);

			var list = new List<string>();
			foreach (var elem in programElements)
			{
				var el = GetElementString(elem);
				list.Add(el);
			}
			//var v = list.Select(item => "<li>" + item + "</li>");
			return Json(list.Select(item => "<li>" + item + "</li>"));
		}
		
		public string GetElementString(ExerciseElement elem)
		{
			string element = elem.ExerciseName + ": ";
			if (elem.Sets > 0)
				element += "Sets: " + elem.Sets;
			if (elem.Reps > 0)
				element += ", Reps:" + elem.Reps;
			if (elem.Time != null)
				element += ", Time" + elem.Time.Value.ToShortTimeString();
			if (elem.Distance != null)
				element += ", Distance:" + elem.Reps;

			return element;
		}
		// GET: ExerciseProgram/Edit/5
		public ActionResult Edit(int id)
		{
			var program = _exerciseProgramService.GetById(id);
			var model = new ExerciseProgramViewModel
			{
				Title = program.Title,
				Category = program.Category,
				Level = program.Level,
				CreatedBy = program.CreatedBy,
				Public = program.Public,
				Id = program.Id,
			};
			return View(model);
		}

		// POST: ExerciseProgram/Edit/5
		[HttpPost]
		public ActionResult Edit(ExerciseProgramViewModel model)
		{
			try
			{
				ExerciseProgram program = _exerciseProgramService.GetById(model.Id);

				program.Title = model.Title;
				program.Category = model.Category;
				program.Level = model.Level;
				program.Public = model.Public;

				_exerciseProgramService.Update(program);
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}


		public ActionResult Details(int id)
		{
			var program = _exerciseProgramService.GetById(id);
			return View(program);
		}

		[HttpPost]
		public ActionResult Delete(int id)
		{
			_elementService.DeleteEPElements(id);
			_exerciseProgramService.DeleteEP(id);
			return RedirectToAction("Index");
		}


		[HttpGet]
		public JsonResult ExerciseAutocomplete(string query)
		{
			var result = new List<KeyValuePair<int, string>>();

			List<Exercise> exercises = _exerciseService.GetExercises();
			var list = exercises.Where(s => s.Title.ToLower().Contains(query.ToLower())).Select(w => w).ToList();

			foreach (var item in list)
			{
				result.Add(new KeyValuePair<int, string>(item.Id, item.Title));
			}
			return Json(result, JsonRequestBehavior.AllowGet);
		}
	}
}