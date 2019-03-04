using System;

namespace Singleton
{
  class Program
  {
    static void Main(string[] args)
    {
			Singleton s1 = Singleton.GetInstance();
			Singleton s2 = Singleton.GetInstance();

			if(s1.Equals(s2))
				Console.WriteLine("All ok, both variables are equal");
			else
				Console.WriteLine("Hm... They doesn't equal...");

			if(Object.ReferenceEquals(s1,s2))
				Console.WriteLine("All ok, both variables have got the same reference");
			else
				Console.WriteLine("Hm... There are different references...");
    }
  }

	public class Singleton
	{
		private static Singleton _nstance;
		private static Object _lock = new Object();

		public static Singleton GetInstance()
		{
			lock(_lock)
			{
				return _nstance ?? (_nstance = new Singleton());
			}
		}
	}
}
