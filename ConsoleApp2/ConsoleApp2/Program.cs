using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp2
{
	//class OnjMessageFilter : IMessageFilter
	//{
	//	bool IMessageFilter.PreFilterMessage(ref Message m)
	//	{
	//		if (m.Msg == 0x201)
	//		{
	//			Console.WriteLine("마우스 클릭 필터링됨..");
	//			// 필터에서 처리했으니 응용프로그램에서 처리안해도 된다는 의미
	//			// Form에 걸려 있는 Click 이벤트 동작 안함 
	//			return true;
	//		}
	//		return false;
	//	}
	//}

	//class Program : Form
	//{
	//	static void Main()
	//	{
	//		Application.AddMessageFilter(new OnjMessageFilter());
	//		Program p = new Program();
	//		p.Click += (sender, e) =>
	//		{
	//			Console.WriteLine("마우스 클릭 이벤트 발생..");
	//			Application.Exit();
	//		};

	//		Application.Run(p);
	//	}
	//}

	class Program : Form
	{
		//public void MouseHandler(object sender, MouseEventArgs e)
		//{
		//	Console.WriteLine("sender: " + ((Form)sender).Text);
		//	Console.WriteLine("name: " + ((Form)sender).Name);
		//	Console.WriteLine("X:{0}, Y:{1}", e.X, e.Y);
		//	Console.WriteLine("Button:{0}, Clicks:{1}", e.Button, e.Clicks);
		//}

		public Program(string title)
		{
			this.Text = title;
			this.Name = "윈폼";
			this.MouseDown += (sender, e) =>
			{
				Console.WriteLine("sender: " + ((Form)sender).Text);
				Console.WriteLine("name: " + ((Form)sender).Name);
				Console.WriteLine("X:{0}, Y:{1}", e.X, e.Y);
				Console.WriteLine("Button:{0}, Clicks:{1}", e.Button, e.Clicks);
			};
		}

		static void Main(string[] args)
		{
			Application.Run(new Program("마우스 이벤트 예제"));
		}
	}
}
