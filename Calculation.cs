using System;

namespace MathsApp
{
	public enum UserDifficulty
	{
		Easy,
		Normal,
		Hard
	}

	public enum MathOperation
	{
		Addition = 1,
		Subtraction = 2,
		Multiplication = 3,
		Division = 4,
		Power = 5,
		SquareRoot = 6
	}

	public class Calculation
	{
		public static (int operationMin, int operationMax) GetPossibleOperationsByDifficulty(UserDifficulty userDifficulty)
		{

			switch (userDifficulty)
			{
				case UserDifficulty.Easy:
					return (1, 4);
				case UserDifficulty.Normal:
					return (1, 5);
				case UserDifficulty.Hard:
					return (3, 7);
				default:
					throw new Exception();
			}
		}

		public static (string message, double correctAnswer) GetMathsEquation(MathOperation mathOperation, UserDifficulty userDifficulty)
		{
			int number1;
			int number2;
			Random randomNumber = new Random();

			switch (mathOperation)
			{
				case MathOperation.Addition:
					number1 = randomNumber.Next(1000);
					number2 = randomNumber.Next(1000);
					return ($"{number1} + {number2}", number1 + number2);
				case MathOperation.Subtraction:
					number1 = randomNumber.Next(1000);
					number2 = randomNumber.Next(1000);
					return ($"{number1} - {number2}", number1 - number2);
				case MathOperation.Multiplication:
					number1 = userDifficulty == UserDifficulty.Easy ? randomNumber.Next(13) : randomNumber.Next(1000);
					number2 = userDifficulty == UserDifficulty.Easy ? randomNumber.Next(13) : randomNumber.Next(1000);
					return ($"{number1} * {number2}", number1 * number2);
				case MathOperation.Division:
					number1 = randomNumber.Next(10000);
					number2 = randomNumber.Next(1000);
					return ($"{number1} / {number2}", number1 / (double)number2);
				case MathOperation.Power:
					number1 = randomNumber.Next(20);
					number2 = randomNumber.Next(5);
					return ($"{number1} ^ {number2}", Math.Pow(number1, number2));
				case MathOperation.SquareRoot:
					number1 = randomNumber.Next(1000);
					return ($"√{number1}", Math.Sqrt(number1));
				default:
					throw new Exception();
			}
		}

		public class OperationQuestionScore
		{
			public int AdditionQuestion { get; private set; }
			public int AdditionScore { get; private set; }
			public int SubtractionQuestion { get; private set; }
			public int SubtractionScore { get; private set; }
			public int MultiplicationQuestion { get; private set; }
			public int MultiplicationScore { get; private set; }
			public int DivisionQuestion { get; private set; }
			public int DivisionScore { get; private set; }
			public int PowerQuestion { get; private set; }
			public int PowerScore { get; private set; }
			public int SquareRootQuestion { get; private set; }
			public int SquareRootScore { get; private set; }
			public int TotalScore { get; private set; }

			public void Increment(MathOperation mathOperation, bool isCorrect)
			{
				if (isCorrect == true)
				{
					switch (mathOperation)
					{
						case MathOperation.Addition:
							AdditionQuestion++;
							AdditionScore++;
							break;
						case MathOperation.Subtraction:
							SubtractionQuestion++;
							SubtractionScore++;
							break;
						case MathOperation.Multiplication:
							MultiplicationQuestion++;
							MultiplicationScore++;
							break;
						case MathOperation.Division:
							DivisionQuestion++;
							DivisionScore++;
							break;
						case MathOperation.Power:
							PowerQuestion++;
							PowerScore++;
							break;
						case MathOperation.SquareRoot:
							SquareRootQuestion++;
							SquareRootScore++;
							break;
					}
					TotalScore++;
				}
				else
				{
					switch (mathOperation)
					{
						case MathOperation.Addition:
							AdditionQuestion++;
							break;
						case MathOperation.Subtraction:
							SubtractionQuestion++;
							break;
						case MathOperation.Multiplication:
							MultiplicationQuestion++;
							break;
						case MathOperation.Division:
							DivisionQuestion++;
							break;
						case MathOperation.Power:
							PowerQuestion++;
							break;
						case MathOperation.SquareRoot:
							SquareRootQuestion++;
							break;
					}
				}
			}
		}
	}
}
