using System;
using System.ServiceModel;

namespace Pipes
{
	public class Receiver : IDisposable
	{		
		private PipeService _ps = new PipeService();
		private ServiceHost _host;

		public void ServiceOn()
		{
			_host = new ServiceHost(_ps, new Uri(PipeService.Uri));

			_host.AddServiceEndpoint(typeof(IPipeService), new NetNamedPipeBinding(), "Pipe1");
			_host.Open();
		}

		public void ServiceOff()
		{
			if (_host != null && _host.State != CommunicationState.Closed)
			{
				_host.Close();
			}
		}

		public void Dispose()
		{
			ServiceOff();

			_ps = null;
		}
	}
}