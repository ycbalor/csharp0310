using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ChatServer
{
	class ClientHadndler
	{
		NetworkStream stream = null;
		StreamReader reader = null;
		StreamWriter writer = null;
		Socket socket = null;

		public ClientHadndler(Socket socket)
		{
			this.socket = socket;
			ChatServer.list.Add(socket);
		}

		public void Chat()
		{
			Encoding encode = Encoding.GetEncoding("euc-kr");
			stream = new NetworkStream(socket);
			reader = new StreamReader(stream, encode);

			try
			{
				while (true)
				{
					string str = reader.ReadLine();
					Console.WriteLine(str);

					foreach (Socket s in ChatServer.list)
					{
						stream = new NetworkStream(s);
						writer = new StreamWriter(stream, encode) { AutoFlush = true };
						writer.WriteLine(str);
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			finally
			{
				ChatServer.list.Remove(socket);
				socket.Close();
				socket = null;
			}
		}
	}


	class ChatServer
	{

		// 클라이언트가 다수 접속하므로 서버가 AcceptSocket 으로 생성한   
		// 클라이언트 상대하는 소켓을 ArrayList등에 보관하고 글을 쓸 때   
		// 현재 접속한 클라이언트 모두에게 글을 보내야 한다.   
		public static List<Socket> list = new List<Socket>();

		public static void Main()
		{
			//IP주소를 나타내는 객체,TcpListener를 생성시 인자로 사용     
			IPAddress ip = IPAddress.Parse("127.0.0.1");

			try
			{
				//TcpListener Class를 이용하여 클라이언트의 연결을 받아 들인다.       
				TcpListener listener = new TcpListener(ip, 5001);
				listener.Start();

				//서버프로그램은 데몬프로그램처럼 늘 기동되어 있어야 하므로 무한루프로       
				while (true)
				{
					Socket socket = listener.AcceptSocket();
					new Thread(() => chat(socket)).Start();
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}

		//Thread가 실행할 메소드, 인자로 클라이언트 전담 소켓을 받는다.   
		static void chat(Socket socket)
		{
			Encoding encoding = Encoding.GetEncoding("euc-kr");
			try
			{
				list.Add(socket);

				StreamReader reader = new StreamReader(new NetworkStream(socket), encoding);
				string line;

				while ((line = readLine(reader)) != null)
				{
					Console.WriteLine(line);

					// ArrayList에 보관된 모든 클라이언트 처리 소켓만큼         
					// 현재 접속한 모든 클라이언트에게 글을 씀         
					foreach (Socket clientSocket in list)
					{
						//클라이언트의 데이터를 읽고, 쓰기 위한 스트림을 만든다.  
						NetworkStream stream = new NetworkStream(clientSocket);
						StreamWriter writer = new StreamWriter(stream, encoding) { AutoFlush = true };
						writer.WriteLine(line);
						writer.Close();
					}
				}
			}
			catch
			{
			}
			finally
			{
				list.Remove(socket);
				socket.Close();
				socket = null;
			}
		}

		static string readLine(StreamReader reader)
		{
			try
			{
				return reader.ReadLine();
			}
			catch
			{
				return null;
			}
		}
	}
}

		
