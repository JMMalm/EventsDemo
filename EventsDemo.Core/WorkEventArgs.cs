using System;

namespace EventsDemo.Core
{
	/// <summary>
	/// A modest event providing a message and timestamp of the event.
	/// </summary>
	/// <remarks>
	/// This event is essentially a message being passed from
	/// an employee about their work status.
	/// </remarks>
	public class WorkEventArgs : EventArgs
	{
		public DateTime Date { get; private set; }
		public string Message { get; private set; }

		public WorkEventArgs(string message)
		{
			Date = DateTime.Now;
			Message = message;
		}
	}
}
