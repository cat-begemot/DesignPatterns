using System;

namespace Proxy
{
  class Program
  {
    static void Main(string[] args)
    {
			Client client = new Client();
			Console.WriteLine("Client: Executing the client code with a real subject:");
			ISubject subject = new RealSubject();
			client.ClientCode(subject);

			Console.WriteLine();

			Console.WriteLine("Client: Exectuing the same client code with a proxy:");
			subject = new Proxy((RealSubject)subject);
			client.ClientCode(subject);
    }
  }

	public class Client
	{
		public void ClientCode(ISubject subject)
		{
			subject.Request();
		}
	}



	public interface ISubject
	{
		void Request();
	}

	public class RealSubject : ISubject
	{
		public void Request()
		{
			Console.WriteLine("RealSubject: Handling Request.");
		}
	}

	public class Proxy : ISubject
	{
		private RealSubject realSubject;

		public Proxy(RealSubject realS)
		{
			realSubject = realS;
		}

		public void Request()
		{
			if(CheckAccess())
			{
				this.LogAccess();
				realSubject = new RealSubject();
				realSubject.Request();
			}
		}

		public Boolean CheckAccess()
		{
			Console.WriteLine("Proxy: Checking access prior to firing a real request.");
			return true;
		}

		public void LogAccess()
		{
			Console.WriteLine("Proxy: Logging the time request.");
		}
	}
}
