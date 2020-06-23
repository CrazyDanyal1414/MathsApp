using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace MathsApp
{
	public class SaveLastTestResults
    {
		[Serializable]
		public class ToFile
		{
			public int TotalScore { get; private set; }
			public int NumberOfQuestions { get; }
			public UserDifficulty UserDifficulty { get; }
			public double TotalEasyQuestion { get; }
			public double TotalEasyScore { get; }
			public double TotalNormalQuestion { get; }
			public double TotalNormalScore { get; }
			public double TotalHardQuestion { get; }
			public double TotalHardScore { get; }
			public double EasyTests { get; }
			public double NormalTests { get; }
			public double HardTests { get; }
			public int TwoPlayerChallenge { get; }

			public ToFile(int numberOfQuestions, UserDifficulty userDifficulty, int totalScore, double totalEasyQuestion, double totalEasyScore, double totalNormalQuestion, double totalNormalScore, double totalHardQuestion, double totalHardScore, double easyTests, double normalTests, double hardTests, int twoPlayerChallenge)
			{
				NumberOfQuestions = numberOfQuestions;
				UserDifficulty = userDifficulty;
				TotalScore = totalScore;
				TotalEasyQuestion = totalEasyQuestion;
				TotalEasyScore = totalEasyScore;
				TotalNormalQuestion = totalNormalQuestion;
				TotalNormalScore = totalNormalScore;
				TotalHardQuestion = totalHardQuestion;
				TotalHardScore = totalHardScore;
				EasyTests = easyTests;
				NormalTests = normalTests;
				HardTests = hardTests;
				TwoPlayerChallenge = twoPlayerChallenge;
			}
		}

		public class SaveToFile
		{
			public static void SerializeLastTest(int numberOfQuestions, int totalScore, UserDifficulty userDifficulty, string userName, double totalEasyQuestion, double totalEasyScore, double totalNormalQuestion, double totalNormalScore, double totalHardQuestion, double totalHardScore, double easyTests, double normalTests, double hardTests, int twoPlayerChallenge)
			{
				ToFile obj = new ToFile(numberOfQuestions, userDifficulty, totalScore, totalEasyQuestion, totalEasyScore, totalNormalQuestion, totalNormalScore, totalHardQuestion, totalHardScore, easyTests, normalTests, hardTests, twoPlayerChallenge);
				IFormatter formatter = new BinaryFormatter();
				Stream stream = new FileStream($"{userName}.gitignore", FileMode.Create, FileAccess.Write);
				formatter.Serialize(stream, obj);
				stream.Close();
			}
			public static ToFile DeserializeLastTest(string userName)
			{
					Stream stream = new FileStream($"{userName}.gitignore", FileMode.Open, FileAccess.Read);
					IFormatter formatter = new BinaryFormatter();
					ToFile objnew = (ToFile)formatter.Deserialize(stream);
					stream.Close();
					return objnew;
			}
		}
	}
}
