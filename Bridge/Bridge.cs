using System;

namespace Bridge
{
  class Program
  {
    static void Main(string[] args)
    {
			Abstraction abstraction;

			abstraction = new Abstraction(new ConcreteImplementationA());
			Client.ClientCode(abstraction);

			abstraction = new ExtendedAbstraction(new ConcreteImplementationB());
			Client.ClientCode(abstraction);
    }
  }

	public static class Client
	{
		public static void ClientCode(Abstraction abstraction)
		{
			Console.Write(abstraction.Operation());
		}
	}

	public class Abstraction
	{
		protected IImplemenation _implementaion;

		public Abstraction(IImplemenation implementation)
		{
			_implementaion = implementation;
		}

		public virtual String Operation()
		{
			return "Abstract: Base operation with:\n" +
				_implementaion.OperationImplementation();
		}
	}

	public class ExtendedAbstraction: Abstraction
	{
		public ExtendedAbstraction(IImplemenation implemenation) : base(implemenation)
		{

		}

		public override string Operation()
		{
			return "ExtendedAbstraction: Extended operation with:\n" +
				base._implementaion.OperationImplementation();
		}
	}

	public interface IImplemenation
	{
		String OperationImplementation();
	}

	public class ConcreteImplementationA : IImplemenation
	{
		public String OperationImplementation()
		{
			return "ConcreteImplementationA: The result in platform A.\n";
		}
	}

	public class ConcreteImplementationB : IImplemenation
	{
		public String OperationImplementation()
		{
			return "ConcreteImplementationB: The result in platform B.\n";
		}
	}


}
