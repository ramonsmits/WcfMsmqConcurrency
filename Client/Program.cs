using System;
using System.Net;
using System.ServiceModel;
using System.Threading;
using System.Transactions;
using Contract;

namespace Client
{
	class Program
	{

		static void Main()
		{
			var f = new ChannelFactory<IHelloWorldService>("Client.HelloWorldService");

			int count = 0;

			var c = f.CreateChannel();

			while (true)
			{
				using (var t = new TransactionScope())
				{
					Console.Write("Enter number of message to create:");
					var nr = int.Parse(Console.ReadLine());
					for (int i = 0; i < nr; i++)
					{
						var data = new CallData
						{
							At = DateTime.Now,
							Nr = Interlocked.Increment(ref count),
							Payload = new byte[1024],
							Host = Dns.GetHostName(),
						};

						Console.WriteLine(data);
						c.Call(data);
					}

					t.Complete();
				}
			}
		}
	}
}
