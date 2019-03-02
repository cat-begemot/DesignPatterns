using System;

namespace Decorator
{
  class Program
  {
    static void Main(string[] args)
    {
			Client client = new Client();

			var simple = new ConcreteComponent();
			Console.WriteLine("Client: I get a simple component");
			client.ClientCode(simple);

			ConcreteDecoratorA decorator1 = new ConcreteDecoratorA(simple);
			Console.WriteLine("Client: now I've got a decorated component:");
			client.ClientCode(decorator1);
			ConcreteDecoratorB decorator2 = new ConcreteDecoratorB(decorator1);
			Console.WriteLine("Client: now I've got a decorated decorator1:");
			client.ClientCode(decorator2);
    }
  }

	public class Client
	{
		public void ClientCode(Component component)
		{
			Console.WriteLine($"RESULT: {component.Operation()}");
		}
	}



	public abstract class Component
	{
		public abstract String Operation();
	}

	public class ConcreteComponent : Component
	{
		public override string Operation()
		{
			return "ConcreteComponent";
		}
	}

	public abstract class Decorator : Component
	{
		protected Component _component;

		public Decorator(Component component)
		{
			_component = component;
		}

		public override string Operation()
		{
			if (_component != null)
				return _component.Operation();
			else
				return String.Empty;

		}
	}

	public class ConcreteDecoratorA : Decorator
	{
		public ConcreteDecoratorA(Component component) : base(component)
		{

		}

		public override string Operation()
		{
			return $"ConcreteDecoratorA({base.Operation()})";
		}
	}

	public class ConcreteDecoratorB : Decorator
	{
		public ConcreteDecoratorB(Component component) : base(component)
		{

		}

		public override string Operation()
		{
			return $"ConcreteDecoratorB({base.Operation()})";
		}
	}
}
