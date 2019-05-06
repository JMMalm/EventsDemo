using System;
using System.Threading.Tasks;

namespace EventsDemo.Core
{
	/// <summary>
	/// A very simple representation of a manager object.
	/// </summary>
	public class Manager : Employee
	{
		/// <summary>
		/// The default constructor.
		/// </summary>
		/// <param name="name">The manager's name. Can be first name and include last name.</param>
		public Manager(string name) : base(name)
		{
			Name = name;
		}

		/// <summary>
		/// Simulates a day-to-day activity of a manager.
		/// </summary>
		/// <returns>A <c>Task</c> with details of the operation.</returns>
		public override async Task DoWork()
		{
			/* This is one way of running an asynchronous operation. Program execution will
			 * continue along while this completes on a separate thread.
			 */
			await Task.Run(() =>
			{
				Console.WriteLine($"{Name}: Working on manager things right now...");
			});
		}

		/// <summary>
		/// Activities to be done when an Employee has completed a figurative task.
		/// </summary>
		/// <param name="sender">The calling object of the event.</param>
		/// <param name="e">A custom event object with details about the event.</param>
		/// <remarks>
		/// <c>object sender</c> is part of a "default" signature for event-handling. You can pass any
		/// object as-is, or make the method signature more specific.
		/// </remarks>
		public void OnWorkCompleted(object sender, WorkEventArgs e)
		{
			// Here we make use of some data provided by the custom event object.
			Console.WriteLine($">>> {sender}: {e.Message} ({e.Date})");
			Console.WriteLine($"{this.Name}: Good, {sender}, now go work on something else.");
		}
	}
}
