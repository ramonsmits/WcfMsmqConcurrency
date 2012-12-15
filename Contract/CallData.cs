using System;

namespace Contract
{
	public class CallData
	{
		public DateTime At { get; set; }
		public int Nr { get; set; }
		public byte[] Payload { get; set; }
		public string Host { get; set; }

		public override string ToString()
		{
			return Nr + "|" + Host + "|" + At + "|" + (Payload == null ? 0 : Payload.Length);
		}
	}
}