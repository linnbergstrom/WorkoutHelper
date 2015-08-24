using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using WorkoutHelper.Domain.Migrations;
using WorkoutHelper.Domain.Models;

namespace WorkoutHelper.Domain.Data
{

	public class WorkoutHelperContext :  IdentityDbContext<ApplicationUser>
	{		
		public WorkoutHelperContext()
			: base("name=WorkoutHelperConnection")
		{
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<WorkoutHelperContext, Configuration>("WorkoutHelperConnection"));
			//Database.SetInitializer(new DropCreateDatabaseAlways<WorkoutHelperContext>());
		}

		public DbSet<Workout> Workouts { get; set; }
		public DbSet<ExerciseProgram> ExercisePrograms { get; set; }
		public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<ExerciseElement> ExerciseElements { get; set; }

		public static WorkoutHelperContext Create()
		{
			return new WorkoutHelperContext();
		}
	}

	/*public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext()
			: base("WorkoutHelperConnection", throwIfV1Schema: false)
		{
			//Database.SetInitializer(new DropCreateDatabaseAlways<ApplicationDbContext>());
		}

		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}
	}*/

}