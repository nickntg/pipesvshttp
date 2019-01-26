using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Running;
using RestSharp;

namespace HttpClient
{
	class Program
	{
		public static void Main()
		{
			System.Threading.Thread.Sleep(4000);

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

	public class O
	{
		public string Value { get; set; }
	}

	[SimpleJob(RunStrategy.Monitoring, baseline: false, launchCount: 1, warmupCount: 10, targetCount: 30, invocationCount: 10000)]
	public class Benchmark
	{
		private RestClient _client;
		private RestRequest _request;

		[GlobalSetup]
		public void Setup()
		{
			//_client = new RestClient("http://localhost:5000/");
			_client = new RestClient("http://localhost/HttpServer/");
			_request = new RestRequest("api/values", Method.POST);
			_request.AddHeader("Content-Type", "application/json");
			_request.AddJsonBody(new O { Value = "test message" });
		}

		[Benchmark]
		public void SendMessage()
		{
			_client.Execute(_request);
		}
	}
}