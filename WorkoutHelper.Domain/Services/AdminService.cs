using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using WorkoutHelper.Domain.Data;
using WorkoutHelper.Domain.Models;

namespace WorkoutHelper.Domain.Services
{
	public class AdminService
	{
		private readonly WorkoutHelperContext db;
		//private readonly ApplicationDbContext _userContext;

		public AdminService()
		{
			db = new WorkoutHelperContext();
			//_userContext = new ApplicationDbContext();
		}


		public List<Exercise> GetExercises()
		{
		 return db.Exercises.ToList();
		}

		public List<ExerciseProgram> GetApprovedPrograms()
		{
			return db.ExercisePrograms.Where(e =>e.PublicApproved==true).ToList();
		}

		//public List<string> GetMuscleList()
		//{
		//	return _context..ToList();
		//}
		public List<User> GetUserList()
		{
			//var users = _userContext.Users.ToList();
			var users = db.Users.ToList();
			var userList = new List<User>();
			foreach (var user in users)
			{
				var person = new User
				{
					Email = user.Email,
					Id = user.Id,
					UserEmailConfirmed = user.EmailConfirmed
				};
				userList.Add(person);
			}

			return userList;
		}

		public List<ExerciseProgram> GetForApproval()
		{
			var forApproval = db.ExercisePrograms.Where(p => p.Public == true).ToList();
			forApproval = forApproval.Where(e => e.PublicApproved == null).ToList();
			return forApproval;
		}

		public bool ApproveEP(int id)
		{
			var program = db.ExercisePrograms.First(p => p.Id == id);
			program.PublicApproved = true;
			db.SaveChanges();
			return true;
		}
		public bool DisapproveEP(int id)
		{
			var program = db.ExercisePrograms.First(p => p.Id == id);
			program.PublicApproved = false;
			db.SaveChanges();
			return true;
		}
		public bool ReconsiderEP(int id)
		{
			var program = db.ExercisePrograms.First(p => p.Id == id);
			program.PublicApproved = null;
			db.SaveChanges();
			return true;
		}
	}
}