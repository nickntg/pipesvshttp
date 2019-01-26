using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Running;
using Pipes;

namespace PipeClient
{
	class Program
	{
		static void Main()
		{
			System.Threading.Thread.Sleep(1000);

			try
			{
				var summary = BenchmarkRunner.Run<Benchmark>(new DebugBuildConfig());

				Console.WriteLine(summary);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
			Console.ReadLine();
		}
	}

	[SimpleJob(RunStrategy.Monitoring, baseline: false, launchCount: 1, warmupCount: 10, targetCount:30, invocationCount:10000)]
	public class Benchmark
	{
		private Sender _client;

		[GlobalSetup]
		public void Setup()
		{
			_client = new Sender();
		}

		[Benchmark]
		public void SendMessage()
		{
			_client.SendMessage("Test message");
		}
	}
}
