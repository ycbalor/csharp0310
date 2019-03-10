using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace SocketServer
{
	class Program
	{
		static void Main(string[] args)
		{
			NetworkStream stream = null;
			TcpListener tcpListener = null;
			Socket clientSocket = null;
			StreamReader reader = null;
			StreamWriter writer = null;

			try
			{
				// IP주소를 나타내는 객체를 생성, TcpListener를 생성시 인자로 사용하려고.
				IPAddress ipAd = IPAddress.Parse("127.0.0.1"); // 자신의 아이피를 넣음

				// TcpListener Class를 이용하여 클라이언트의 연결을 받아들인다.
				tcpListener = new TcpListener(ipAd, 5001); // 서버를 만든다.
				tcpListener.Start(); // 서버가 떴다.

				// Client의 접속이 올때까ㅏ지 Block되는 부분, 대개 이 부분을 Thread로 만들어 보내버린다.
				// 백그라운드 Thread에 처리를 맡긴다.
				// 뱅글뱅글 돌면서 요청을 기다리고 요청을 요청큐에 집어 넣어서 담고 땡겨온다. 
				clientSocket = tcpListener.AcceptSocket(); 

				// 클라이언트의 데이터를 읽고, 쓰기 위한 스트림을 만든다.
				stream = new NetworkStream(clientSocket);
				Encoding encode = Encoding.GetEncoding("utf-8");

				// 스트림은 한 라인씩 읽어들이려고 쓴 것임 (안써도됨)
				reader = new StreamReader(stream, encode);
				writer = new StreamWriter(stream, encode) { AutoFlush = true };


				// 서버는 무한 루프를 돌면서 읽어들인다.
				while (true)
				{
					string str = reader.ReadLine(); // 받는다.
					Console.WriteLine(str);
					writer.WriteLine(str); // 보낸다.
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			finally
			{
				clientSocket.Close();
			}
		}
	}
}
