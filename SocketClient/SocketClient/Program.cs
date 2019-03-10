using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

// 클라이언트에서 요청 큐에 저장
// 서버에서 요청큐에서 하나 빼와서 소켓을 하나 만듬
// 소켓을 가지고 스트림을 생성한다

namespace SocketClient
{
	class Program
	{
		static void Main(string[] args)
		{
			TcpClient client = null;

			try
			{
				// LocalHost에 지정 포트로 TCP Connection을 생성하고 데이터를 송수신 하기위한 스트림을 얻는다.
				client = new TcpClient();
				client.Connect("localhost", 5001);

				
				NetworkStream stream = client.GetStream();

				// 버퍼에 남아있는 찌꺼기 자동으로 플러시해라. (보내라)
				StreamWriter writer = new StreamWriter(stream) { AutoFlush = true };
				StreamReader reader = new StreamReader(stream);

				string dataToSend = Console.ReadLine();
				while (true)
				{
					writer.WriteLine(dataToSend); // 보낸다.
					string str = reader.ReadLine(); // 받는다.
					Console.WriteLine(str); // 출력한다.

					if (dataToSend.IndexOf("<EOF>") > -1)
						break;
					dataToSend = Console.ReadLine();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			finally
			{
				client.Close();
			}
		}
	}
}
