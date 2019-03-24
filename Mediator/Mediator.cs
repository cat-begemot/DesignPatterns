
using System;

namespace Mediator
{
	internal class Program
	{
		internal static void Main(string[] args)
		{
			var component1 = new Component1();
			var component2 = new Component2();
			var mediator = new ConcreteMediator(component1, component2);

			component1.SetMediator(mediator);
			component2.SetMediator(mediator);

			component1.DoA();

			Console.WriteLine();

			component2.DoD();
		}
	}



	public interface IMediator
	{
		void Notify(Object sender, String ev);
	}

	public class ConcreteMediator : IMediator
	{
		private Component1 component1;
		private Component2 component2;

		public ConcreteMediator(
			Component1 c1,
			Component2 c2)
		{
			component1 = c1;
			component2 = c2;
		}

		public void Notify(object sender, string ev)
		{
			if(ev=="A")
			{
				Console.WriteLine("Mediator reacts on A and triggers following operations");
				this.component2.DoC();
			}
			if(ev=="D")
			{
				Console.WriteLine("Mediator reacts in D and triggers following operations");
					this.component1.DoB();
				this.component2.DoC();
			}
		}
	}

	public class BaseComponent
	{
		protected IMediator mediator;

		public BaseComponent(IMediator concreteMediator=null)
		{
			this.mediator = concreteMediator;
		}

		public void SetMediator(IMediator concreteMediator)
		{
			this.mediator = concreteMediator;
		}
	}

	public class Component1 : BaseComponent
	{
		public void DoA()
		{
			Console.WriteLine("Component1 does A");
			this.mediator.Notify(this, "A");
		}

		public void DoB()
		{
			Console.WriteLine("Component1 does B");
			this.mediator.Notify(this, "B");
		}
	}

	public class Component2 : BaseComponent
	{
		public void DoC()
		{
			Console.WriteLine("Component2 does C");
			this.mediator.Notify(this, "C");
		}

		public void DoD()
		{
			Console.WriteLine("Component2 does D");
			this.mediator.Notify(this, "D");
		}
	}
}
