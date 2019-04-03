using System;

namespace TemplateMethod
{
	class Program
	{
		static void Main(string[] args)
		{
			Client.ClientCode(new ConcreteClass1());
			Console.WriteLine();
			Client.ClientCode(new ConcreteClass2());
		}
	}

	public abstract class AbstractClass
	{
		public void TemplateMethod()
		{
			this.BaseOperation1();
			this.RequiredOperation1();
			this.BaseOperation2();
			this.Hook1();
			this.RequiredOperation2();
			this.BaseOperation3();
			this.Hook2();

		}

		protected void BaseOperation1()
		{
			Console.WriteLine("Base operation #1");
		}

		protected void BaseOperation2()
		{
			Console.WriteLine("Base operation #2");
		}

		protected void BaseOperation3()
		{
			Console.WriteLine("Base operation #3");
		}

		protected abstract void RequiredOperation1();

		protected abstract void RequiredOperation2();

		protected virtual void Hook1() { }

		protected virtual void Hook2() { }
	}

	public class ConcreteClass1 : AbstractClass
	{
		protected override void RequiredOperation1()
		{
			Console.WriteLine("Concrete class #1: Required operation #1");
		}

		protected override void RequiredOperation2()
		{
			Console.WriteLine("Concrete class #1: Required operation #2");
		}
	}

	public class ConcreteClass2 : AbstractClass
	{
		protected override void RequiredOperation1()
		{
			Console.WriteLine("Concrete class #2: Required operation #1");
		}

		protected override void RequiredOperation2()
		{
			Console.WriteLine("Concrete class #2: Required operation #2");
		}

		protected override void Hook1()
		{
			Console.WriteLine("Concrete class #2: Hook #1");
		}
	}

	public class Client
	{
		public static void ClientCode(AbstractClass concreteClass)
		{
			concreteClass.TemplateMethod();
		}
	}
}
