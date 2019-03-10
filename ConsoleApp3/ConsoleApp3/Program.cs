using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ConsoleApp3
{
	class Program : Form
	{
		static void Main(string[] args)
		{
			Button button1 = new Button();
			button1.Text = "메시지";
			button1.Left = 50;
			button1.Top = 50;
			button1.Click += (sender, e) =>
			{
				MessageBox.Show("버튼 클릭");
			};


			Button button2 = new Button();
			button2.Text = "종료";
			button2.Left = 150;
			button2.Top = 50;

			button2.Click += (sender, e) =>
			{
				MessageBox.Show("종료");
				Application.Exit();
			};

			Program p = new Program();
			p.Text = "윈폼 예제";
			p.Height = 150;
			p.Controls.Add(button1);
			p.Controls.Add(button2);
			Application.Run(p);

		}
	}
}
