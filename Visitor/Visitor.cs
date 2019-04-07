using System;
using System.Collections.Generic;

namespace Visitor
{
  public class Program
  {
    public static void Main(string[] args)
    {
			List<IComponent> components = new List<IComponent>()
			{
				new ConcreteComponentA(),
				new ConcreteComponentB()
			};

			Console.WriteLine("The client code works with all visitors via the base Visitor interface:");
			IVisitor visitor1 = new ConcreteVisitor1();
			Client.ClientCode(components, visitor1);

			Console.WriteLine();

			Console.WriteLine("It allows same client code to work with different type of Visitor");
			IVisitor visitor2 = new ConcreteVisitor2();
			Client.ClientCode(components, visitor2);
    }
  }

	public interface IComponent
	{
		void Accept(IVisitor visitor);
	}

	public class ConcreteComponentA : IComponent
	{
		public void Accept(IVisitor visitor)
		{
			visitor.VisitConcreteComponentA(this);
		}

		public String ExclusiveMethodOfConcreteComponentA()
		{
			return "A";
		}
	}

	public class ConcreteComponentB : IComponent
	{
		public void Accept(IVisitor visitor)
		{
			visitor.VisitConcreteComponentB(this);
		}

		public String SpecialMethodOfConcreteComponentB()
		{
			return "B";
		}
	}

	public interface IVisitor
	{
		void VisitConcreteComponentA(ConcreteComponentA element);
		void VisitConcreteComponentB(ConcreteComponentB element);
	}

	public class ConcreteVisitor1 : IVisitor
	{
		public void VisitConcreteComponentA(ConcreteComponentA element)
		{
			Console.WriteLine(element.ExclusiveMethodOfConcreteComponentA() + " + ConcreteVisitor1");
		}

		public void VisitConcreteComponentB(ConcreteComponentB element)
		{
			Console.WriteLine(element.SpecialMethodOfConcreteComponentB() + " + ConcreteVisitor1");
		}
	}

	public class ConcreteVisitor2 : IVisitor
	{
		public void VisitConcreteComponentA(ConcreteComponentA element)
		{
			Console.WriteLine(element.ExclusiveMethodOfConcreteComponentA() + " + ConcreteVisitor2");
		}

		public void VisitConcreteComponentB(ConcreteComponentB element)
		{
			Console.WriteLine(element.SpecialMethodOfConcreteComponentB() + " + ConcreteVisitor2");
		}
	}

	public class Client
	{
		public static void ClientCode(List<IComponent> components, IVisitor visitor)
		{
			foreach (var component in components)
				component.Accept(visitor);
		}
	}
}
