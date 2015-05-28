using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Web.UI.WebControls;

namespace WorkoutHelper.Domain.Models
{
   public class ExerciseCalendar
    {
	   public int Id { get; set; }
	   public string Title { get; set; }
	   public DateTime Today { get; set; }
	   public int WeekNumber { get; set; }
	   public DayOfWeek FirstDayOfWeek { get; set; }
    }
}
