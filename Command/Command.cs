using System;

namespace Command
{
  class Program
  {
    static void Main(string[] args)
    {
			Invoker invoker = new Invoker();
			invoker.SetOnStart(new SimpleCommand("Say hi!"));
			Receiver receiver = new Receiver();
			invoker.SetOnFinish(new ComplexCommand(receiver, "Send email", "Save report"));

			invoker.DoSomethingImportant();
    }



		public interface ICommand
		{
			void Execute();
		}

		public class SimpleCommand : ICommand
		{
			private String payload = String.Empty;

			public SimpleCommand(String payL)
			{
				payload = payL;
			}

			public void Execute()
			{
				Console.WriteLine($"SimpleCommand: See, I can do simple things like printing {this.payload}");
			}
		}

		public class ComplexCommand : ICommand
		{
			private Receiver receiver;
			private String a;
			private String b;

			public ComplexCommand(Receiver com_r, String com_a, String com_b)
			{
				this.receiver = com_r;
				this.a = com_a;
				this.b = com_b;
			}

			public void Execute()
			{
				Console.WriteLine("Complex command: Complex stuff should be done by a receiver object");
				this.receiver.DoSomething(this.a);
				this.receiver.DoSomethingElse(this.b);
			}
		}

		public class Receiver
		{
			public void DoSomething(String a)
			{
				Console.WriteLine($"Receiver: Working on {a}.");
			}

			public void DoSomethingElse(String b)
			{
				Console.WriteLine($"Receiver: Also working on {b}");
			}
		}

		public class Invoker
		{
			private ICommand onStart;
			private ICommand onFinish;

			public void SetOnStart(ICommand command)
			{
				onStart = command;
			}

			public void SetOnFinish(ICommand command)
			{
				onFinish = command;
			}

			public void DoSomethingImportant()
			{
				Console.WriteLine("Invoker: Does anybody want something done before I begin?");
				if (onStart is IC ommand)
					onStart.Execute();

				Console.WriteLine("Invoker: ...doing something really important...");

				Console.WriteLine("Invoker: Does anybody want something dome after I finish?");
				if (onFinish is ICommand)
					onFinish.Execute();
			}
		}
	}
}
