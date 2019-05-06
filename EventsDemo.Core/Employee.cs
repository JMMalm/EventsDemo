using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EventsDemo.Core
{
	/// <summary>
	/// A very simple representation of an employee object.
	/// </summary>
	public class Employee
	{
		/// <summary>
		/// A simple event indicating an employee's task (both figuratively and technically here) has completed.
		/// </summary>
		public event EventHandler<WorkEventArgs> WorkCompleted;

		/// <summary>
		/// The employee's name. (first name assumed, can include last name)
		/// </summary>
		public string Name { get; protected set; }

		/// <summary>
		/// The default constructor.
		/// </summary>
		/// <param name="name">The employee's name. Can be first name and include last name.</param>
		public Employee(string name)
		{
			Name = name;
		}

		/// <summary>
		/// Simulates the employee working on a task.
		/// </summary>
		/// <returns>A <c>Task</c> with details of the operation.</returns>
		public virtual async Task DoWork()
		{
			/* This is one way of running an asynchronous operation. Program execution will
			 * continue along while this completes on a separate thread.
			 */
			await Task.Run(() =>
			{
				// Simulate doing your work here. A real-life scenario could be making a HTTP request or database query.
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

		/// <summary>
		/// Checks if our event handler has any subscribers matching the argument.
		/// </summary>
		/// <param name="methodName">The method name to search for.</param>
		/// <returns>True if there is a matched method subscribed to this event.</returns>
		/// <remarks><c>GetInvocationList() must be called within the class having the event handler.</c></remarks>
		public bool HasMethodAsEventHandler(string methodName)
		{
			return (bool)WorkCompleted?
				.GetInvocationList()
				.Any( i => string.Equals(i.Method.Name, methodName, StringComparison.InvariantCultureIgnoreCase));
		}
	}
}
