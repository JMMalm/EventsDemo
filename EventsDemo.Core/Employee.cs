using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EventsDemo.Core
{
	public class Employee
	{
		/// <summary>
		/// A simple event indicating an employee's task (both figuratively and technically here) has completed.
		/// </summary>
		public event EventHandler<WorkEventArgs> WorkCompleted;

		public string Name { get; protected set; }

		public Employee(string name)
		{
			Name = name;
		}

		public virtual async Task DoWork()
		{
			await Task.Run(() =>
			{
				// Simulate doing your work here.
				Console.WriteLine($"{Name}: Doing my work now...");
				Thread.Sleep(5000);

				/* Fire the event, notifying all subscribers. This event handler will be null if no one
				 * is subscribing to it. Can also override the sender with any object or variable type.
				 */
				if (WorkCompleted != null)
				{
					WorkCompleted.Invoke(Name, new WorkEventArgs("I've completed my work!"));
				}
				else
				{
					Console.WriteLine($"{Name}: Moving on to something else now...");
				}
			});
		}

		public bool HasMethodAsEventHandler(string methodName)
		{
			return (bool)WorkCompleted?
				.GetInvocationList()
				.Any( i => string.Equals(i.Method.Name, methodName, StringComparison.InvariantCultureIgnoreCase));
		}
	}
}
