using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// Interrupt 이용한 쓰레드 종료방법
namespace ThreadEnd
{
	class Program
	{
		public static Thread sleeperThread;
		static void Main(string[] args)
		{
			sleeperThread = new Thread(ThreadToSleep);
			sleeperThread.Start();
			sleeperThread.Interrupt();
		}

		private static void ThreadToSleep()
		{
			int i = 0;

			while (true)
			{
				Console.WriteLine("[Sleeper:" + i++ + "]");

				if (i == 9)
				{
					try
					{
						Console.WriteLine("i가 9가 되어 1초 쉼..");
						Thread.Sleep(1000);
					}
					catch (ThreadInterruptedException)
					{
						Console.WriteLine("ThreadInterruptedException...");
						Environment.Exit(0);
					}
				}
			}
		}
	}
}
