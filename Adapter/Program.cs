using System;

namespace Adapter
{
  class Program
  {
    static void Main(string[] args)
    {
			Adaptee adaptee = new Adaptee();
			ITarget target = new Adapter(adaptee);

			Console.WriteLine("Adaptee interface is incompatible with the client");
			Console.WriteLine("But wit adapter client can call it's method");
			Console.WriteLine(target.GetRequest());
    }
  }

	public interface ITarget
	{
		String GetRequest();
	}

	public class Adaptee
	{
		public String GetSpecificRequest()
		{
			return "Specific request.";
		}
	}

	public class Adapter : ITarget
	{
		private readonly Adaptee _adaptee;

		public Adapter(Adaptee adaptee)
		{
			_adaptee = adaptee;
		}

		public string GetRequest()
		{
			return $"This is '{this._adaptee.GetSpecificRequest()}'";
		}
	}
}
