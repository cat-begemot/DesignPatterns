using System;
using System.Collections.Generic;

namespace Chain
{
  class Program
  {
    static void Main(string[] args)
    {
			var monkey = new MonkeyHandler();
			var squirrel = new SquirrelHandler();
			var dog = new DogHandler();

			monkey.SetNext(squirrel).SetNext(dog);

			Console.WriteLine("Chain: Monkey > Squirrel > Dog");
			Client.ClientCode(monkey);
			Console.WriteLine();

			Console.WriteLine("Subchain: Squirrel > Dog");
			Client.ClientCode(squirrel);
    }

		public class Client
		{
			public static void ClientCode(AbstractHandler handler)
			{
				foreach(var food in new List<String>() { "Nut", "Banana", "Cup of coffee"})
				{
					Console.WriteLine($"Client: Who wants a {food}?");
					var result = handler.Handle(food);
					if (result != null)
						Console.WriteLine($"{result}");
					else
						Console.WriteLine($"    {food} was left untouched");
				}
			}
		}





		public interface IHandler
		{
			IHandler SetNext(IHandler handler);

			Object Handle(Object request);
		}

		public abstract class AbstractHandler : IHandler
		{
			private IHandler nextHandler;

			public virtual Object Handle(Object request)
			{
				if (this.nextHandler != null)
					return this.nextHandler.Handle(request);
				else
					return null;
			}

			public IHandler SetNext(IHandler handler)
			{
				this.nextHandler = handler;
				return handler;
			}
		}

		public class MonkeyHandler : AbstractHandler
		{
			public override Object Handle(Object request)
			{
				if ((request as String) == "Banana")
					return $"Monkey: I'll eat the {request.ToString()}.";
				else
					return base.Handle(request);
			}
		}

		public class SquirrelHandler : AbstractHandler
		{
			public override Object Handle(Object request)
			{
				if ((request as String) == "Nut")
					return $"Squirrel: I'll eat the {request.ToString()}.";
				else
					return base.Handle(request);
			}
		}

		public class DogHandler : AbstractHandler
		{
			public override Object Handle(Object request)
			{
				if ((request as String) == "MeatBall")
					return $"Dog: I'll eat the {request.ToString()}.";
				else
					return base.Handle(request);
			}
		}
	}
}
