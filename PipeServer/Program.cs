using System;
using Pipes;

namespace PipeServer
{
	class Program
	{
		static void Main()
		{
			var server = new Receiver();
			try
			{
				server.ServiceOn();
				Console.WriteLine("Serving");
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}

			Console.ReadLine();
		}
	}
}