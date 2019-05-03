using System;
using System.Collections.Generic;
using System.Text;

namespace EventsDemo.Core
{
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
