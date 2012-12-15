using System;
using System.Diagnostics;
using System.ServiceModel;
using System.Threading;
using Contract;

namespace Server
{
	[ServiceBehavior(
		ReleaseServiceInstanceOnTransactionComplete = false,
		//InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single // Singleton, synchronous
		//InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple // Singleton, concurrent
		//InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Single // Transient, concurrent
		InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple // Transient, concurrent
		)]
	public class HelloWorldService : IHelloWorldService
	{
		private static readonly Stopwatch Start = Stopwatch.StartNew();
		static int _total;
		static int _instances;
		static int _active;
		readonly int _instance = ++_instances;
		int _calls;

		[OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
		public void Call(CallData data)
		{
			Interlocked.Increment(ref _total);
			Interlocked.Increment(ref _active);
			Interlocked.Increment(ref _calls);

			Console.WriteLine(
				"#{6} I:{1} C:{5} T:{2} E:{3} A:{4} S:{7}| '{0}'",
				data,
				_instance,
				Thread.CurrentThread.ManagedThreadId,
				Start.Elapsed,
				_active,
				_calls,
				_total,
				DateTime.Now - data.At
				);

			Thread.Sleep(500);
			Interlocked.Decrement(ref _active);
		}
	}
}