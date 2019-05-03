using System;
using System.Threading.Tasks;

namespace EventsDemo.Core
{
	public class Manager : Employee
	{
		public Manager(string name) : base(name)
		{
			Name = name;
		}

		public override async Task DoWork()
		{
			await Task.Run(() =>
			{
				Console.WriteLine($"{Name}: Working on manager things right now...");
			});
		}

		public void OnWorkCompleted(object sender, WorkEventArgs e)
		{
			Console.WriteLine($">>> {sender}: {e.Message} ({e.Date})");
			Console.WriteLine($"{this.Name}: Good, {sender}, now go work on something else.");
		}
	}
}
