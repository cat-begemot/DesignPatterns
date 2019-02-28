using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Sync
{
  class Program
  {
		static void Main(string[] args)
    {
			Task.Factory.StartNew(() => {
				Console.WriteLine("Hello World");
			});

			// wait for input before exiting 
			Console.WriteLine("Main method complete. Press enter to finish.");
			Console.ReadLine();
		}

		private static void CallerWithAwaiter()
		{
			TraceThreadAndTask($"starting {nameof(CallerWithAwaiter)}");
			TaskAwaiter<String> awaiter = GreetingAsync("Alex").GetAwaiter();
			awaiter.OnCompleted(OnCompleteAwaiter);

			void OnCompleteAwaiter()
			{
				Console.WriteLine(awaiter.GetResult());
				TraceThreadAndTask($"ended {nameof(CallerWithAwaiter)}");
			}
		}


		private async static void CallerWithAsync()
		{
			TraceThreadAndTask($"started {nameof(CallerWithAsync)}");
			Console.WriteLine(await GreetingAsync("Alex"));
			TraceThreadAndTask($"ended {nameof(CallerWithAsync)}");
		}

		internal static String Greeting(String name)
		{
			TraceThreadAndTask($"running {nameof(Greeting)}");
			Task.Delay(5000).Wait();
			return $"Hello {name}";
		}

		internal static Task<String> GreetingAsync(String name)
		{
			return Task.Run<String>(() =>
			{
				TraceThreadAndTask($"running {nameof(GreetingAsync)}");
				return Greeting(name);
			});
		}

		public static void TraceThreadAndTask(String info)
		{
			Int32? currentId = Task.CurrentId;
			String taskInfo = currentId == null ? "no task" : "task " + currentId;
			Console.WriteLine($"{info} in thread {Thread.CurrentThread.ManagedThreadId} and {taskInfo}");
		}
	}
}
