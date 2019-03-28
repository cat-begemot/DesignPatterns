using System;

namespace State
{
	class Program
	{
		static void Main(string[] args)
		{
			var context = new Context(new ConcreteStateA());

			context.Request1();
			context.Request2();
		}
	}

	public class Context
	{
		private State _state = null;

		public Context(State state)
		{
			this.TranslationTo(state);
		}

		public void TranslationTo(State state)
		{
			Console.WriteLine($"Context: Translation to {state.GetType().Name}");
			this._state = state;
			this._state.SetContext(this);
		}

		public void Request1()
		{
			this._state.Handle1();
		}

		public void Request2()
		{
			this._state.Handle2();
		}
	}

	public abstract class State
	{
		protected Context _context;

		public void SetContext(Context context)
		{
			this._context = context;
		}

		public abstract void Handle1();

		public abstract void Handle2();
	}

	public class ConcreteStateA : State
	{
		public override void Handle1()
		{
			Console.WriteLine("ConcreteStateA handles request1.");
			Console.WriteLine("ConcreteStateA wnats to change the state of the context.");
			this._context.TranslationTo(new ConcreteStateB());
		}

		public override void Handle2()
		{
			Console.WriteLine("ConcreteStateA handles request2");
		}
	}

	public class ConcreteStateB : State
	{
		public override void Handle1()
		{
			Console.WriteLine("ConcreteStateB handles reuest1");
		}

		public override void Handle2()
		{
			Console.WriteLine("ConcreteStateB handle request2");
			Console.WriteLine("ConcreteStateB wants to change the state of the context.");
			this._context.TranslationTo(new ConcreteStateA());
		}
	}
}
