using System.ServiceModel;

namespace Contract
{
	[ServiceContract(SessionMode = SessionMode.NotAllowed)]
	public interface IHelloWorldService
	{
		[OperationContract(IsOneWay = true)]
		void Call(CallData data);
	}
}
