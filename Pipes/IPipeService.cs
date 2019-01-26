using System.ServiceModel;

namespace Pipes
{
	[ServiceContract (Namespace = "http://www.nohost.com/pipe1")]
	public interface IPipeService
	{
		[OperationContract]
		void ProcessMessage(string data);
	}
}