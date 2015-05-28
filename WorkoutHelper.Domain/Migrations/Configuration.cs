using System.Collections.Generic;
using System.Web.UI.WebControls;
using WorkoutHelper.Domain.Enums;
using WorkoutHelper.Domain.Models;

namespace WorkoutHelper.Domain.Migrations
{
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;

	internal sealed class Configuration : DbMigrationsConfiguration<Data.WorkoutHelperContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = true;
			AutomaticMigrationDataLossAllowed = true;
		}

		//protected override void Seed(Data.WorkoutHelperContext context)
		//{
		//	ExerciseProgram exerciseProg = new ExerciseProgram()
		//	{
		//		Title = "Strong Lifts",
		//		Category = Enums.WkCategory.Strength,
		//		Creator = "Admin",
		//	};
		//	ExerciseProgram exerciseProg2 = new ExerciseProgram()
		//	{
		//		Title = "100 Pushups",
		//		Category = Enums.WkCategory.Strength,
		//		Creator = "Admin",
		//		Level = WkLevel.Beginner,
		//		Public = true
		//	};

		//	Exercise squat = new Exercise
		//	{
		//		Title = "Squat",
		//		Creator = "Admin",
		//		MainMuscle = WkMuscle.Legs
		//	};
		//	Exercise benchPress = new Exercise
		//	{
		//		Title = "Bench Press",
		//		Creator = "Admin",
		//		MainMuscle = WkMuscle.Chest,
		//		Public = true
		//	};

		//	ProgramElement element1 = new ProgramElement
		//	{
		//		Sets = 3,
		//		Reps = 8,
		//		Exercise =squat
		//	};
		//	ProgramElement element2 = new ProgramElement
		//	{
		//		Sets = 5,
		//		Reps = 5,
		//		Exercise =benchPress
		//	};
		//	Workout workout1 = new Workout
		//	{
		//		ExerciseProgram = exerciseProg,
		//		WorkoutDate = DateTime.Now.AddDays(2),
		//		Title = exerciseProg.Title

		//	};
		//	Workout workout2 = new Workout
		//	{
		//		ExerciseProgram = exerciseProg2,
		//		WorkoutDate = DateTime.Now.AddDays(1),
		//		Title = exerciseProg2.Title

		//	};

		//	context.ExercisePrograms.AddOrUpdate(exerciseProg);
		//	context.ExercisePrograms.AddOrUpdate(exerciseProg2);
		//	context.Exercises.AddOrUpdate(squat);
		//	context.Exercises.AddOrUpdate(benchPress);
		//	context.ProgramElements.AddOrUpdate(element1);
		//	context.ProgramElements.AddOrUpdate(element2);
		//	context.Workouts.AddOrUpdate(workout1);
		//	context.Workouts.AddOrUpdate(workout2);


		//	//context.Subprograms.AddOrUpdate(new SubProgram()
		//	//{
		//	//	Title = "A",
		//	//	ExerciseProgId = 1
		//	//});
		//	//context.Subprograms.AddOrUpdate(new SubProgram()
		//	//{
		//	//	Title = "B",
		//	//	ExerciseProgId = 1
		//	//});
		//}
	}
}
