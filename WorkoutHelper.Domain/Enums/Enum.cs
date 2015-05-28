namespace WorkoutHelper.Domain.Enums
{
	public enum WkForce
	{
		None,
		Push,
		Pull,
		Static
	}

	public enum WkLevel
	{
		Beginner,
		Intermediate,
		Advanced
	}

	public enum WkExerciseType
	{
		Strength,
		Cardio,
		Balance,
		Flexibility
	}

	public enum WkCategory
	{
		Strength,
		Cardio,
		Other
	}

	public enum Weather
	{
		None,
		Sunny,
		Rainy,
		Snowing,
		Storm,
		Snowstorm
	}

	public enum Feeling
	{
		None,
		Bad,
		Okay,
		Good,
		Great,
		Amazing
	}

	//store as strings in DB
	public enum WkMuscle
	{
		None,
		FullBody,
		Arms,
		Legs,
		Back,
		Abs,
		Biceps,
		Calves,
		Chest,
		Forearms,
		Glutes,
		Hamstrings,
		Lats,
		LowerBack,
		MiddleBack,
		Neck,
		Quadriceps,
		Shoulders,
		Traps,
	}
}