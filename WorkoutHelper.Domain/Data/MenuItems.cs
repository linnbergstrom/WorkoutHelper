using System.Collections.Generic;

namespace WorkoutHelper.Domain.Data
{
	public class MenuItem
	{
		public string Title { get; set; }
		public string IconLink { get; set; }
		public string Link { get; set; }
		public string Controller { get; set; }
		public string Action { get; set; }

		public static List<MenuItem> GetMenu()
		{
			var list = new List<MenuItem>
			{
				new MenuItem
				{
					Title = "Today's Workouts",
					IconLink = "",
					Controller = "Workout",
					Action = "TodaysWorkouts"
				},
				new MenuItem
				{
					Title = "My Workouts",
					IconLink = "",
					Controller = "Workout",
					Action = "ListWorkouts"
				},
				new MenuItem
				{
					Title = "New Workout",
					IconLink = "",
					Controller = "Workout",
					Action = "Create"
				},
				new MenuItem
				{
					Title = "My Calendar",
					IconLink = "",
					Controller = "Calendar",
					Action = "Index"
				},
				new MenuItem
				{
					Title = "My Programs",
					IconLink = "",
					Controller = "ExerciseProgram",
					Action = "Index"
				},
				new MenuItem
				{
					Title = "Create New Program",
					IconLink = "",
					Controller = "ExerciseProgram",
					Action = "Create"
				},
				//new MenuItem
				//{
				//	Title = "Create New Exercise",
				//	IconLink = "",
				//	Controller = "Exercise",
				//	Action = "Create"
				//}
			};
			return list;
		}
	}
}