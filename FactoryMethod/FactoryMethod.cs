using System;
using System.IO;
using System.Windows;

namespace Test
{
	internal enum Transport
	{
		Car,
		Vessel,
		Airbus
	}

	internal class Program
	{
		static void Main(string[] args)
		{
			var transport = Transport.Car;

			Creator creator = null;
			if(transport==Transport.Airbus)
				creator = new ConcreteCreator1(); // Define the exact creator for exact class
			else if(transport==Transport.Car)
				creator = new ConcreteCreator2(); // Define the exact creator for exact class
			else if(transport==Transport.Vessel)
				creator = new ConcreteCreator3(); // Define the exact creator for exact class


			IProduct product = creator.FactoryMethod();

			Console.WriteLine(creator.SomeOperation()); 
			Console.WriteLine(product.Operation());
		}
	}


	internal class Client
	{
		public void Main()
		{
			var cc = new ConcreteCreator3(); // Here choose concrete class object
			IProduct cp = cc.FactoryMethod();
			Console.WriteLine(cp.Operation());
		}

		public void ClientCode(Creator creator)
		{
			Console.WriteLine("Client: I'm not aware of the creator's class, " +
				"but it still works.\n" + creator.SomeOperation());
			Console.WriteLine();
		}
	}
	 

	internal abstract class Creator
	{
		internal abstract IProduct FactoryMethod();

		// Common for all child creator classes
		internal String SomeOperation()
		{
			var product = FactoryMethod();
			var result = "Creator: the same creator's code has just worked with " +
				product.Operation();
			return result;
		}
	}



	internal class ConcreteCreator1 : Creator
	{
		internal override IProduct FactoryMethod()
		{
			return new ConcreteProduct1();
		}
	}

	internal class ConcreteCreator2 : Creator
	{
		internal override IProduct FactoryMethod()
		{
			return new ConcreteProduct2();
		}
	}

	internal class ConcreteCreator3 : Creator
	{
		internal override IProduct FactoryMethod()
		{
			return new ConcreteProduct3();
		}
	}






	internal interface IProduct
	{
		String Operation();
	}

	internal class ConcreteProduct1 : IProduct
	{
		public String Operation()
		{
			return "Result of ConcreteProdiction1";
		}
	}

	internal class ConcreteProduct2 : IProduct
	{
		public String Operation()
		{
			return "Result of ConcreteOperation2";
		}
	}

	internal class ConcreteProduct3 : IProduct
	{
		public String Operation()
		{
			return "Result of ConcreteOperation3";
		}
	}
}
