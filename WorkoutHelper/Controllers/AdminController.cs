using System.Web.Mvc;
using WorkoutHelper.Domain.Services;
using WorkoutHelper.ViewModels;

namespace WorkoutHelper.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AdminController : Controller
	{
		private readonly AdminService _adminService;
		private readonly ExerciseProgramService _exerciseProgramService;
		private readonly ExerciseService _exerciseService;
		private readonly ElementService _elementService;

		public AdminViewModel adminmodel
		{
			get
			{
				return new AdminViewModel
					{
						Exercises = _adminService.GetExercises(),
						ApprovedExercisePrograms = _adminService.GetApprovedPrograms(),
						EPForApproval = _adminService.GetForApproval(),
						Users = _adminService.GetUserList()
					};
			}
		}

		public AdminController()
		{
			_adminService = new AdminService();
			_exerciseProgramService = new ExerciseProgramService();
			_exerciseService = new ExerciseService();
			_elementService = new ElementService();
		}

		public ActionResult Index()
		{
			return View(adminmodel);
		}

		[HttpPost]
		public PartialViewResult ApproveEP(int id)
		{
			bool approved = _adminService.ApproveEP(id);
			return PartialView("_EPForApproval", adminmodel);
		}

		[HttpPost]
		public PartialViewResult DisapproveEP(int id)
		{
			bool approved = _adminService.DisapproveEP(id);
			return PartialView("_EPForApproval", adminmodel);
		}

		[HttpPost]
		public PartialViewResult ReconsiderEP(int id)
		{
			bool approved = _adminService.ReconsiderEP(id);
			return PartialView("_EPForApproval", adminmodel);
		}
		[HttpPost]
		public PartialViewResult DeleteEP(int id)
		{
			_elementService.DeleteEPElements(id);
			_exerciseProgramService.DeleteEP(id);
			return PartialView("_EPForApproval", adminmodel);
		}
		public PartialViewResult DeleteExercise(int id)
		{
			_exerciseService.Delete(id);
			return PartialView("_EPForApproval", adminmodel);
		}
	}
}