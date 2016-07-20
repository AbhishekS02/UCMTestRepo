using System;

using NetQoS.VoIP.Inspector.RemoteInterfaces;
using NetQoS.VoIP.Inspector.Types;

namespace NetQoS.VoIP.Inspector.Client 
{
	public class CaptureClient : RemoteClient 
	{
		const string ServiceName = "Capture";

		public CaptureClient(string host, int port, bool isSecure, ServiceList serviceList)
			: base(host, port, isSecure, ServiceName, serviceList, typeof(ICaptureServer))
		{
		}
		
		protected ICaptureServer RemoteServer
		{
			get { return (ICaptureServer) RemoteObject; }
		}

		public static ServiceVersion vCaptureTcp = new ServiceVersion(ServiceName, "CaptureTcp", 1);
		public CaptureResult CaptureTcp(string fileName, string serverIP, ushort minPort, ushort maxPort, string subnetIP, uint subnetMaskBits, int packetBytes, int captureSeconds, int maxFileKBytes)
		{
			Check(ref vCaptureTcp);
			return RemoteServer.CaptureTcp(fileName, serverIP, minPort, maxPort, subnetIP, subnetMaskBits, packetBytes, captureSeconds, maxFileKBytes);
		}
	}

	public delegate CaptureResult AsyncCaptureTcp(string fileName, string serverIP, ushort minPort,
		ushort maxPort, string subnetIP, uint subnetMaskBits, int packetBytes, int captureSeconds, 
		int maxFileKBytes);
}
    
   