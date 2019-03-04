using System;

namespace AbstractFactory
{
  public class Program
  {
    static void Main(string[] args)
    {
			//new Client().Main();
			IAbstractFactory factory = new ConcreteFactory1(); // Initialize a kind of objects
			IAbstractProductA productA = factory.CreateProductA(); // Create object from defined kind

			Console.WriteLine(productA.UsefulFunctionA());

			factory = new ConcreteFactory2();
			productA = factory.CreateProductA();

			Console.WriteLine(productA.UsefulFunctionA());
		}
  }

	public class Client
	{
		public void Main()
		{
			Console.WriteLine("First factory...");
			ClientMethod(new ConcreteFactory1());

			Console.WriteLine();

			Console.WriteLine("Second factory...");
			ClientMethod(new ConcreteFactory2());
		}

		public void ClientMethod(IAbstractFactory factory)
		{
			var productA = factory.CreateProductA();
			var productB = factory.CreateProductB();

			Console.WriteLine(productB.UsefulFunctonB());
			Console.WriteLine(productB.AnotherUsefulFunctionB(productA));
		}
	}


	public interface IAbstractFactory
	{
		IAbstractProductA CreateProductA();
		IAbstractProductB CreateProductB();
	}

	public class ConcreteFactory1 : IAbstractFactory
	{
		public IAbstractProductA CreateProductA()
		{
			return new ConcreteProductA1();
		}

		public IAbstractProductB CreateProductB()
		{
			return new ConcreteProductB1();
		}
	}

	public class ConcreteFactory2 : IAbstractFactory
	{
		public IAbstractProductA CreateProductA()
		{
			return new ConcreteProductA2();
		}

		public IAbstractProductB CreateProductB()
		{
			return new ConcreteProductB2();
		}
	}
	 
	public interface IAbstractProductA
	{
		String UsefulFunctionA();
	}

	public class ConcreteProductA1 : IAbstractProductA
	{
		public string UsefulFunctionA()
		{
			return "The result of the product A1.";
		}
	}

	public class ConcreteProductA2 : IAbstractProductA
	{
		public string UsefulFunctionA()
		{
			return "The result of the product A2.";
		}
	}

	public interface IAbstractProductB
	{
		String UsefulFunctonB();
		String AnotherUsefulFunctionB(IAbstractProductA collaborator);
	}

	public class ConcreteProductB1 : IAbstractProductB
	{
		public string AnotherUsefulFunctionB(IAbstractProductA collaborator)
		{
			var result = collaborator.UsefulFunctionA();
			return $"The result of the B1 collaborating with ({result})";
		}

		public string UsefulFunctonB()
		{
			return "The result of the product B1.";
		}
	}

	public class ConcreteProductB2 : IAbstractProductB
	{
		public string AnotherUsefulFunctionB(IAbstractProductA collaborator)
		{
			var result = collaborator.UsefulFunctionA();
			return $"The result of the B2 collaborating with the ({result})";
		}

		public string UsefulFunctonB()
		{
			return "The result of the product B2.";
		}
	}
}
