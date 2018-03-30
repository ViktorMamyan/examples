internal class Helper
{
	//get tow time different
	internal string TimeDiffer(DateTime startTime, DateTime endTime)
	{
		TimeSpan durationTime = endTime.Subtract(startTime);
		return durationTime.ToString();
	}
}


//usage

DateTime startTime = DateTime.Now;
//do some work
DateTime endTime = DateTime.Now;

Helper helper = new Helper();
helper.TimeDiffer(startTime, endTime)