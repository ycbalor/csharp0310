using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreadLock
{
	class ThreadTest
	{
		public string lockString = "Hello";
		private object obj = new object();
		private static Mutex mutex = new Mutex();

		public void Print(string rank)
		{
			// lock을 걸어놓으면 먼저 들어온 스레드가 해당 임계구간을 모두 실행할 때까지 
			// 다른 스레드는 대기한다.

			//lock (obj)
			//{
			//	for (int i = 0; i < 5; i++)
			//	{
			//		for (int j = 0; j < 5; j++)
			//		{
			//			Thread.Sleep(100);
			//			Console.Write(",");
			//		}
			//		Console.WriteLine("{0}{1}", rank, lockString);
			//	}
			//}

			// 메소드 잠금 (하나의 프로젝트 안에서만 사용 가능)
			//Monitor.Enter(obj);
			//for (int i = 0; i < 5; i++)
			//{
			//	for (int j = 0; j < 5; j++)
			//	{
			//		Thread.Sleep(100);
			//		Console.Write(",");
			//	}
			//	Console.WriteLine("{0}{1}", rank, lockString);
			//}
			//Monitor.Exit(obj);

			// WaitOne을 걸어준 구문은 처음 쓰레드가 끝날때까지 다른 쓰레드가 접근금지
			mutex.WaitOne();
			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 5; j++)
				{
					Thread.Sleep(100);
					Console.Write(",");
				}
				Console.WriteLine("{0}{1}", rank, lockString);
			}
			mutex.ReleaseMutex();
		}

		public void FirstWork()
		{
			Print("F");
		}

		public void SecondWork()
		{
			Print("S");
		}
	}

	class Program
	{
		[MTAThread]
		static void Main(string[] args)
		{
			ThreadTest t = new ThreadTest();
			Thread first = new Thread(t.FirstWork);
			Thread second = new Thread(t.SecondWork);

			first.Start();
			second.Start();
		}
	}
}
