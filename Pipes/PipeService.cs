using System.ServiceModel;

namespace Pipes
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
	public class PipeService : IPipeService
	{
		public static string Uri = "net.pipe://localhost/Pipe";

		public void ProcessMessage(string data)
		{
		}
	}
}