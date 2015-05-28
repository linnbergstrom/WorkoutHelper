using System;
using System.Collections;
using System.Collections.Generic;
using WorkoutHelper.Domain.Models;

namespace WorkoutHelper.ViewModels
{
	public class CalendarViewModel
	{
		public List<Week> Weeks { get; set; }
		public DateTime Today { get; set; }
		public DayOfWeek FirstDayOfWeek { get; set; }
		public string Month { get; set; }
		public string[] DayNames { get; set; }
	}

	public class Week
	{
		public List<Day> Days { get; set; }
		public int WeekNr { get; set; }
	}

	public class Day
	{
		public int DayNr { get; set; }
		public Dictionary<int, string> Workouts { get; set; }
		public int MonthNr { get; set; }
		public DayOfWeek DayName { get; set; }
		public DateTime DaysDate { get; set; }
		public bool IsMonday { get; set; }
		public int WeekNr { get; set; }

	}
}