using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Web.Mvc;

namespace WorkoutHelper.Util
{
	public class DateAttribute : RangeAttribute
	{
		public DateAttribute()
			: base(typeof(DateTime),
					DateTime.Now.AddHours(-1).ToShortDateString(), DateTime.Now.AddYears(1).ToShortDateString())
		{ }
	}
}