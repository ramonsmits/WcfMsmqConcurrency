using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Server
{
	class Program
	{
		static void Main()
		{
			var host = new ServiceHost(typeof(HelloWorldService));
			host.Open();

			Console.WriteLine("Started at {0} on {1}", DateTime.Now, Dns.GetHostName());
			Console.WriteLine("Host is running... Press <Enter> key to stop");
			Console.ReadLine();
		}
	}
}
