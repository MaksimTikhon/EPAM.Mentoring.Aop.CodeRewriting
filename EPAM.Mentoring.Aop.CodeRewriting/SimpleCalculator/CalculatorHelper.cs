using System;
using Logger;

namespace SimpleCalculator
{
	[LoggerPostSharpAspect]
	public class CalculatorHelper
	{
		private const string AvailableOperators = "+-";

		public ParsedInput Parse(string expressin)
		{
			char[] delimiters = { ' ' };
			var operands = expressin.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

			int firstArgument;
			int secondArgument;

			if (operands.Length == 3 && int.TryParse(operands[0], out firstArgument)
					&& int.TryParse(operands[2], out secondArgument) && AvailableOperators.Contains(operands[1]))
			{
				return new ParsedInput
				{
					FirstArgument = firstArgument,
					SecondArgument = secondArgument,
					Operator = operands[1],
					Success = true
				};
			}

			return new ParsedInput
			{
				Success = false
			};
		}

		public long Sum(int firstArgument, int secondArgument)
		{
			return firstArgument + secondArgument;
		}

		public long Subtract(int firstArgument, int secondArgument)
		{
			return firstArgument - secondArgument;
		}
	}
}
