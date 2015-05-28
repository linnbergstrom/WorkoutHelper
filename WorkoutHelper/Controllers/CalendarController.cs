using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using WorkoutHelper.Domain.Models;
using WorkoutHelper.Domain.Services;
using WorkoutHelper.ViewModels;

namespace WorkoutHelper.Controllers
{
	[Authorize]
	public class CalendarController : Controller
	{
		private readonly WorkoutService _workoutService;

		public CalendarController()
		{
			_workoutService = new WorkoutService();
		}

		// GET: Calendar
		public ActionResult Index()
		{
			var cal = new CalendarViewModel();
			List<Week> weeks = new List<Week>();

			Week week = GetDatesWeek(DateTime.Now.AddDays(-14));
			weeks.Add(week);
			week = GetDatesWeek(DateTime.Now.AddDays(-7));
			weeks.Add(week);
			week = GetDatesWeek(DateTime.Now);
			weeks.Add(week);
			week = GetDatesWeek(DateTime.Now.AddDays(+7));
			weeks.Add(week);
			week = GetDatesWeek(DateTime.Now.AddDays(+14));
			weeks.Add(week);

			cal.Weeks = weeks;
			cal.Today = DateTime.Now;
			cal.Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(cal.Today.Month);
			cal.DayNames = CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedDayNames;
			return View(cal);
		}

		private Week GetDatesWeek(DateTime dateinWeek)
		{
			var week = new Week();
			DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
			Calendar myCal = CultureInfo.InvariantCulture.Calendar;

			DayOfWeek monday = myCal.GetDayOfWeek(dateinWeek);
			DateTime startDay = dateinWeek;

			while (monday.ToString() != "Monday")
			{
				startDay = startDay.AddDays(-1);
				monday = myCal.GetDayOfWeek(startDay);
			}

			//generate days
			week.Days  = new List<Day>();
			for (int i = 0; i < 7; i++)
			{
				var day = new Day();
				var date = startDay.AddDays(i);
				day.DayNr = date.Day;
				day.DaysDate = date;
				day.DayName = date.DayOfWeek;
				day.MonthNr = date.Month;
				day.WeekNr = myCal.GetWeekOfYear(date, DateTimeFormatInfo.CurrentInfo.CalendarWeekRule,
					DateTimeFormatInfo.CurrentInfo.FirstDayOfWeek);
				if (date.DayOfWeek == monday)
				{
					day.IsMonday = true;
				}
				week.Days.Add(day);
			}

			List<Workout> workouts = _workoutService.GetWeeksWorkouts(week.Days[0].DaysDate, week.Days[6].DaysDate, User.Identity.Name);

			//Insert Workouts in days
			foreach (var day in week.Days)
			{
				var dateMin = day.DaysDate.Date;
				var dateMax = dateMin.AddDays(1).AddSeconds(-1);
				var col = new Dictionary<int, string>();
				var daysWorkouts = workouts.Where(d => d.WorkoutDate.Date >= dateMin).ToList();
				daysWorkouts = daysWorkouts.Where(d => d.WorkoutDate.Date.AddDays(1).AddSeconds(-1) <= dateMax).ToList();

				foreach (var wo in daysWorkouts)
				{
					string title = wo.Title;
					int id = wo.Id;
					col.Add(id, title);
				}
				day.Workouts = col;
			}

			//Add week number
			week.WeekNr = dfi.Calendar.GetWeekOfYear(dateinWeek, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

			return week;
		}
	}
}