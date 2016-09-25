using Logger;

namespace SimpleCalculator
{
	[LoggerPostSharpAspect]
	public class Caluclator
	{
		private readonly CalculatorHelper _calculatorHelper;

		public Caluclator()
		{
			_calculatorHelper = new CalculatorHelper();
		}

		public CalculatedResult Process(string expressin)
		{
			var parsedInput = _calculatorHelper.Parse(expressin);
			if (parsedInput.Success)
			{
				long result = 0;

				switch (parsedInput.Operator)
				{
					case "+":
						result = _calculatorHelper.Sum(parsedInput.FirstArgument, parsedInput.SecondArgument);
						break;

					case "-":
						result = _calculatorHelper.Subtract(parsedInput.FirstArgument, parsedInput.SecondArgument);
						break;
				}

				return new CalculatedResult
				{
					Result = result,
					Success = true
				};
			}

			return new CalculatedResult
			{
				Success = false
			};
		}
	}
}
