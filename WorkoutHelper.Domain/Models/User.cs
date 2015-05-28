using System.Collections.Generic;

namespace WorkoutHelper.Domain.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
		public string Email { get; set; }
	    public bool UserEmailConfirmed { get; set; }
		//public IEnumerable<Exercise> Exercises { get; set; }
		//public IEnumerable<ExerciseProgram> Programs { get; set; }
		//public IEnumerable<Workout> Workouts { get; set; }
    }
}
