using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy
{
  class Program
  {
    static void Main(string[] args)
    {
			var context = new Context();

			Console.WriteLine("Client: Strategy is set to noraml sorting.");
			context.SetStrategy(new ConcreteStrategyA());
			context.DoSomeBusinessLogic();

			Console.WriteLine();

			Console.WriteLine("Client: Strategy is set to reverse sorting.");
			context.SetStrategy(new ConcreteStrategyB());
			context.DoSomeBusinessLogic();
    }
  }


	public class Context
	{
		private IStrategy _strategy;

		public Context()
		{

		}

		public Context(IStrategy strategy)
		{
			this._strategy = strategy;
		}

		public void SetStrategy(IStrategy strategy)
		{
			this._strategy = strategy;
		}

		public void DoSomeBusinessLogic()
		{
			Console.WriteLine("Context: Sorting data using the strategy (not sure how it'll do it)");
			var result = this._strategy.DoAlgorithm(new List<String>() { "a", "b", "c", "d", "e" });

			StringBuilder resultStr = new StringBuilder();
			foreach (var element in result as List<String>)
				resultStr.Append(element).Append(", ");

			Console.WriteLine(resultStr.ToString());
		}
	}

	public interface IStrategy
	{
		Object DoAlgorithm(Object data);
	}

	public class ConcreteStrategyA : IStrategy
	{
		public object DoAlgorithm(object data)
		{
			var list = data as List<String>;
			list.Sort();

			return list;
		}
	}

	public class ConcreteStrategyB : IStrategy
	{
		public object DoAlgorithm(object data)
		{
			var list = data as List<String>;
			list.Sort();
			list.Reverse();

			return list;
		}
	}
}
