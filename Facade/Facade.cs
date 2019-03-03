using System;
using System.Text;

namespace Facade
{
  class Program
  {
    static void Main(string[] args)
    {
			Subsystem1 sub1 = new Subsystem1();
			Subsystem2 sub2 = new Subsystem2();
			Facade facade = new Facade(sub1, sub2);
			Client.ClientCode(facade);
    }
  }

	public class Client
	{
		public static void ClientCode(Facade facade)
		{
			Console.WriteLine(facade.Operation());
		}
	}


	public class Facade
	{
		protected Subsystem1 subsystem1;
		protected Subsystem2 subsystem2;

		public Facade(Subsystem1 sub1, Subsystem2 sub2)
		{
			this.subsystem1 = sub1;
			this.subsystem2 = sub2;
		}

		public String Operation()
		{
			StringBuilder result = new StringBuilder(200);
			result.Append(this.subsystem1.Operation1()).AppendLine();
			result.Append(this.subsystem2.Operation1()).AppendLine();
			result.Append(this.subsystem1.OperationN()).AppendLine();
			result.Append(this.subsystem2.OperationZ()).AppendLine();

			return result.ToString();
		}
	}

	public class Subsystem1
	{
		public String Operation1()
		{
			return "Subsystem1: Ready!";
		}

		public String OperationN()
		{
			return "Subsystem1: Go!";
		}
	}

	public class Subsystem2
	{
		public String Operation1()
		{
			return "Subsystem2: Get ready!";
		}

		public String OperationZ()
		{
			return "Subsystem2: Fire!";
		}
	}
}
