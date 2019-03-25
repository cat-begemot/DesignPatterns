using System;
using System.Text;
using System.Threading;
using System.Collections;
using System.Collections.Generic;

namespace Memento
{
  internal class Program
  {
    static void Main(string[] args)
    {
			Originator originator = new Originator("Super-puper");
			Caretaker caretaker = new Caretaker(originator);

			caretaker.Buckup();
			originator.DoSomething();

			caretaker.Buckup();
			originator.DoSomething();

			caretaker.Buckup();
			originator.DoSomething();

			Console.WriteLine();
			caretaker.ShowHistory();

			Console.WriteLine("\nClient: Now, let's rollback!\n");
			caretaker.Undo();

			Console.WriteLine("\n\nClient: Once more!\n");
			caretaker.Undo();

			Console.WriteLine("\n\nClient: Once more!\n");
			caretaker.Undo();

			Console.WriteLine();
		}
  }

	public class Originator
	{
		private String _state;

		public Originator(String state)
		{
			this._state = state;
			Console.WriteLine($"My initial state is: {state}");
		}

		public void DoSomething()
		{
			Console.WriteLine("Originator: I'm doiing soemthing important.");
			this._state = this.GenerateRandomString(30);
			Console.WriteLine($"Originator: and my state has changed to: {this._state}");
		}

		private String GenerateRandomString(Int32 Length=10)
		{
			String allowedSymbols = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
			StringBuilder result = new StringBuilder();
			Random rnd = new Random();

			while(Length-->0)
				result.Append(allowedSymbols[rnd.Next(0, allowedSymbols.Length)]);

			return result.ToString();
		}

		public IMemento Save()
		{
			return new ConcreteMemento(this._state);
		}

		public void Restore(IMemento memento)
		{
			if (!(memento is ConcreteMemento))
				throw new Exception("Unknown memento class " + memento.ToString());

			this._state = memento.GetState();
			Console.WriteLine($"Originator: My state has changed to: {this._state}");
		}
	}

	public interface IMemento
	{
		String GetName();
		String GetState();
		DateTime GetDate();
	}

	public class ConcreteMemento : IMemento
	{
		private String _state;
		private DateTime _date;

		public ConcreteMemento(String state)
		{
			this._state = state;
			this._date = DateTime.Now;
		}

		public DateTime GetDate()
		{
			return this._date;
		}

		public string GetName()
		{
			return $"{this._date}/{this._state.Substring(0, 7)}";
		}

		public string GetState()
		{
			return this._state;
		}
	}

	public class Caretaker
	{
		private Stack<IMemento> _mementos = new Stack<IMemento>();
		private Originator _originator = null;

		public Caretaker(Originator originator)
		{
			this._originator = originator;
		}

		public void Buckup()
		{
			Console.WriteLine("\nCaretaker; Saving Originator's state...");
			this._mementos.Push(this._originator.Save());
		}

		public void Undo()
		{
			if (this._mementos.Count == 0)
				return;

			var memento = this._mementos.Pop();
			Console.WriteLine($"Caretaker: Restoring state to: {memento.GetName()}");
			try
			{
				this._originator.Restore(memento);
			}
			catch(Exception ex)
			{
				this.Undo();
			}
		}

		public void ShowHistory()
		{
			Console.WriteLine("Caretaker: Here's the list of mementos:");
			foreach(var memento in this._mementos)
				Console.WriteLine(memento.GetName());
		}
	}
}
