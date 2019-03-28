using System;
using System.Collections.Generic;

namespace Observer
{
	class Program
	{
		static void Main(string[] args)
		{
			var subject = new Subject();
			var observerA = new ConcreteObserverA();
			var observerB = new ConcreteObserverB();

			subject.Attach(observerA);
			subject.Attach(observerB);

			subject.SomeBusinessLogic();
			subject.SomeBusinessLogic();

			subject.Detach(observerB);

			subject.SomeBusinessLogic();
			subject.SomeBusinessLogic();
		}
	}


	public interface IObserver
	{
		void Update(ISubject subject);
	}

	public interface ISubject
	{
		void Attach(IObserver observer);
		void Detach(IObserver observer);
		void Notify();
	}

	public class Subject : ISubject
	{
		public Int32 State { get; set; } = 0;

		private List<IObserver> _observers = new List<IObserver>();

		public void Attach(IObserver observer)
		{
			Console.WriteLine("Subject: Attached an observer");
			this._observers.Add(observer);
		}

		public void Detach(IObserver observer)
		{
			Console.WriteLine("Detached an observer");
			this._observers.Remove(observer);
		}

		public void Notify()
		{
			Console.WriteLine("Subject: Notifying observers...");
			foreach (var observer in this._observers)
				observer.Update(this);
		}

		public void SomeBusinessLogic()
		{
			Console.WriteLine("\nSubject: I'm doing something important.");
			this.State = new Random().Next(0, 10);
			Console.WriteLine($"Subject: My state has just changed to: {this.State}");
			this.Notify();
		}
	}

	public class ConcreteObserverA : IObserver
	{
		public void Update(ISubject subject)
		{
			if((subject as Subject).State<3)
				Console.WriteLine("ConcreteObserverA: Reacted to the event");
		}
	}

	public class ConcreteObserverB : IObserver
	{
		public void Update(ISubject subject)
		{
			if((subject as Subject).State==0 || (subject as Subject).State>=2)
				Console.WriteLine("ConcreteObserverB: Reacted to the event.");	
		}
	}

}
