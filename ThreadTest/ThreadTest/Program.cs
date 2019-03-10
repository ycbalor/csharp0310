using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTest
{
	// 1번
	//class Program
	//{
	//	[MTAThread]
	//	static void Main(string[] args)
	//	{
	//		Program p = new Program();

	//		//ThreadStart는 스레드를 시작시켜주는 델리게이트
	//		Thread first = new Thread(p.FirstWork); // new 생략
	//		Thread second = new Thread(new ThreadStart(p.SecondWork)); // 원형

	//		first.Priority = ThreadPriority.Lowest; // 스레드 우선순위 할당
	//		second.Priority = ThreadPriority.Highest; 
	//		// 스레드 우선순위가 높으면 CPU에게 기용을 더받음
	//		// OS마다 다르지만 second가 더 많이 돌것임

	//		first.Start();
	//		second.Start();
	//	}

	//	public void FirstWork()
	//	{
	//		for (int i = 0; i < 100; i++)
	//		{
	//			// 지정된 시간동안 있다가 깨어남
	//			Thread.Sleep(1000); //ms
	//			Console.WriteLine("F{0} ", i);
	//		}
	//	}

	//	public void SecondWork()
	//	{
	//		for (int i = 0; i < 100; i++)
	//		{
	//			Thread.Sleep(1000); //ms
	//			Console.WriteLine("F{0} ", i);
	//		}
	//	}
	//}

	// 2번
	//class ThreadTest
	//{
	//	public bool sleep = false;

	//	public void FirstWork()
	//	{
	//		for (int i = 0; i < 10; i++)
	//		{
	//			Thread.Sleep(1000);
	//			Console.WriteLine("F{0}", i);

	//			if (i == 5)
	//			{
	//				sleep = true;
	//				Console.WriteLine("");
	//				Console.WriteLine("first 쉼..");
	//				Thread.CurrentThread.Suspend();
	//			}
	//		}
	//	}

	//	public static void Main()
	//	{
	//		ThreadTest p = new ThreadTest();

	//		Thread first = new Thread(p.FirstWork);

	//		first.Start();

	//		while (p.sleep == false)
	//		{
	//			Console.WriteLine("first를 깨웁니다.. 2초 후 깨어납니다..");
	//			Thread.Sleep(2000);
	//			first.Resume();
	//		}
	//	}
	//}

	// 3번
	//class ThreadTest
	//{
	//	bool sleep = false;

	//	// 차단기가 내려간 상태
	//	static AutoResetEvent autoEvent = new AutoResetEvent(false);

	//	public void FirstWork()
	//	{
	//		for (int i = 0; i < 10; i++)
	//		{
	//			Thread.Sleep(1000);
	//			Console.WriteLine("F{0}", i);

	//			if (i == 5)
	//			{
	//				sleep = true;
	//				Console.WriteLine("");
	//				Console.WriteLine("first 쉼..");
	//				autoEvent.WaitOne();
	//			}
	//		}
	//	}

	//	public static void Main()
	//	{
	//		ThreadTest p = new ThreadTest();

	//		Thread first = new Thread(p.FirstWork);

	//		first.Start();

	//		while (p.sleep == false)
	//		{
	//			Console.WriteLine("first를 깨웁니다.. 2초 후 깨어납니다..");
	//			Thread.Sleep(2000);
	//			autoEvent.Set();
	//		}
	//	}
	//}


	// 4번
	class Program
	{
		private static int count = 0;
		public static EventWaitHandle _WaitHandle;

		static void Main()
		{
			Console.Write("1:AutoResetEvent\n:ManualResetEvetn\n..........");
			switch (Console.ReadKey().KeyChar)
			{
				case '1':
					// 차단기가 올라간 상태
					_WaitHandle = new AutoResetEvent(true);
					break;

				case '2':
					_WaitHandle = new ManualResetEvent(true);
					break;
			}
			Console.WriteLine("");

			Thread T1 = new Thread(DoWork);
			Thread T2 = new Thread(DoWork);

			T1.Start();
			T2.Start();

		}

		static private void DoWork()
		{
			_WaitHandle.WaitOne();
			for (int i = 0; i < 5; i++)
			{
				Console.WriteLine(count++);
				Thread.Sleep(500);
			}

		}
	}
}
