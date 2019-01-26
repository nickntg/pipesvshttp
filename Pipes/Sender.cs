using System.Runtime.InteropServices;
using System.ServiceModel;

namespace Pipes
{
	public class Sender
	{
		private readonly IPipeService _proxy;

		public Sender()
		{
			var ep = new EndpointAddress($"{PipeService.Uri}/Pipe1");
			_proxy = ChannelFactory<IPipeService>.CreateChannel(new NetNamedPipeBinding(), ep);
		}

		public void SendMessage(string message)
		{
			_proxy.ProcessMessage(message);

		}
	}
}