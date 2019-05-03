using System;
using EventsDemo.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventsDemo
{
	public class Program
	{
		public static Employee Jordon { get; private set; }
		public static Manager Loren { get; private set; }

		static void Main(string[] args)
		{
			Jordon = new Employee("Jordon");
			Loren = new Manager("Loren");

			Console.WriteLine($"+++ Now running 'Has subscriber' scenario +++ {Environment.NewLine}");
			ScenarioHasSubscriber();

			Console.WriteLine($"{Environment.NewLine}+++ Now running 'No subscriber' scenario +++ {Environment.NewLine}");
			ScenarioNoSubscriber();

			Console.WriteLine($"{Environment.NewLine}Press any key to quit.");
			Console.Beep();
			Console.ReadKey();
		}

		private static void ScenarioHasSubscriber()
		{
			/* Link the event to a method of the subscribing object.
			 * When "WorkCompleted" is invoked, the event-handler on the
			 * right side of the assignment will run.
			 */
			Jordon.WorkCompleted += Loren.OnWorkCompleted;

			Task[] tasks =
			{
				// Run an independent method that will eventually invoke the event.
				Jordon.DoWork(),
				Loren.DoWork()
			};

			Task.WaitAll(tasks);
		}

		private static void ScenarioNoSubscriber()
		{
			if (Jordon.HasMethodAsEventHandler("OnWorkCompleted"))
			{
				// This will remove the method as an event handler.
				Jordon.WorkCompleted -= Loren.OnWorkCompleted;
			}

			// No event-handling will be invoked by this method.
			Task.WaitAll(Jordon.DoWork());
		}
	}
}