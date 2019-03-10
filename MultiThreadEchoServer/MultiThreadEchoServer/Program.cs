using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Net;

namespace MultiThreadEchoServer
{
	class ClientHandler
	{
		Socket socket = null;
		NetworkStream stream = null;
		StreamReader reader = null;
		StreamWriter writer = null;

		public ClientHandler(Socket socket)
		{
			this.socket = socket;
		}

		public void Chat()
		{
			// 클라이언트의 데이터를 읽고 쓰기위한 스트림을 만든다.
			stream = new NetworkStream(socket);
			Encoding encode = Encoding.GetEncoding("utf-8");

			reader = new StreamReader(stream, encode);
			writer = new StreamWriter(stream, encode) { AutoFlush = true };

			while (true)
			{
				string str = reader.ReadLine();
				Console.WriteLine(str);
				writer.WriteLine(str);
			}
		}
	}

	class Server
	{
		static void Main(string[] args)
		{
			TcpListener tcpListener = null;
			Socket clientSocket = null;

			try
			{
				IPAddress ipAd = IPAddress.Parse("127.0.0.1");

				tcpListener = new TcpListener(ipAd, 5001);
				tcpListener.Start();

				while (true)
				{

					clientSocket = tcpListener.AcceptSocket();
					ClientHandler cHandlere = new ClientHandler(clientSocket);
					Thread t = new Thread(cHandlere.Chat);
					t.Start();
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
