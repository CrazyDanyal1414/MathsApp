using System;
using static MathsApp.SaveLastTestResults;

namespace MathsApp
{
    public class CanUseManyTimes
    {
		public static string ReadInput()
		{
			string input = Console.ReadLine();
			Console.Write(new string(' ', 100));
			Console.CursorLeft = 0;
			return input;
		}

		static readonly object lockObject = new object();

		public static void WriteToScreen(string message, bool resetCursor)
		{
			lock (lockObject)
			{
				if (resetCursor)
				{
					int leftPos = Console.CursorLeft;
					Console.WriteLine();
					Console.Write(message.PadRight(50, ' '));
					Console.CursorTop--;
					Console.CursorLeft = leftPos;
				}
				else
				{
					Console.WriteLine(message);
					Console.Write(new string(' ', 100));
					Console.CursorLeft = 0;
				}
			}
		}

		public static UserDifficulty SuggestingDifficulty(string userName)
		{
			ToFile objnew = SaveToFile.DeserializeLastTest(userName);
			UserDifficulty userDifficulty = UserDifficulty.Easy;

			Console.WriteLine($"Last time you did the test on {objnew.UserDifficulty} level and got {objnew.TotalScore}/{objnew.NumberOfQuestions}");
			double decimalScore = (double)objnew.TotalScore / (double)objnew.NumberOfQuestions;

			if (objnew.UserDifficulty == UserDifficulty.Easy)
			{
				if (decimalScore <= 0.7)
				{
					Console.WriteLine($"You should stay on Easy difficulty");
					userDifficulty = UserDifficulty.Easy;
				}
				else
				{
					Console.WriteLine($"Easy difficulty seems to easy for you💪! You should go up to Normal difficulty");
					userDifficulty = UserDifficulty.Normal;
				}
			}
			else if (objnew.UserDifficulty == UserDifficulty.Normal)
			{
				if (decimalScore <= 0.3)
				{
					Console.WriteLine($"Normal difficulty seems to be to hard for you☹️. You should go down to Easy difficulty");
					userDifficulty = UserDifficulty.Easy;
				}
				else if ((decimalScore > 0.3) && (decimalScore <= 0.7))
				{
					Console.WriteLine($"You should stay on Normal difficulty");
					userDifficulty = UserDifficulty.Normal;
				}
				else
				{
					Console.WriteLine($"Normal difficulty seems to easy for you💪! You should go up to Hard difficulty");
					userDifficulty = UserDifficulty.Hard;
				}
			}
			else if (objnew.UserDifficulty == UserDifficulty.Hard)
			{
				if (decimalScore <= 0.3)
				{
					Console.WriteLine($"Hard difficulty seems to hard for you☹️. You should go down to Normal difficulty");
					userDifficulty = UserDifficulty.Normal;
				}
				else if ((decimalScore > 0.3) && (decimalScore <= 0.8))
				{
					Console.WriteLine($"You should stay on Hard difficulty");
					userDifficulty = UserDifficulty.Hard;
				}
				else
				{
					Console.WriteLine($"You are a maths Genius🥳! Sadly this is the hardest level");
					userDifficulty = UserDifficulty.Hard;
				}
			}
			return userDifficulty;
		}
	}
}
