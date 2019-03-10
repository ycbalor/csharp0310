using System;
using System.Net;
using System.Net.Mail;

namespace GoogleSMTP
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				// 메일 아이디, 비밀번호 입력
				var credentials = new NetworkCredential("메일주소", "비밀번호");

				// 메일 정보 입력
				var mail = new MailMessage()
				{
					From = new MailAddress("내 메일"),
					Subject = "Test email",
					Body = "Test email body"
				};

				// 보내기
				mail.To.Add(new MailAddress("상대편 메일"));


				var client = new SmtpClient()
				{
					Port = 587,
					DeliveryMethod = SmtpDeliveryMethod.Network,
					UseDefaultCredentials = false,
					Host = "smtp.gmail.com",
					EnableSsl = true,
					Credentials = credentials
				};

				client.Send(mail);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error in sendig email:" + ex.Message);
				Console.ReadKey();
				return;
			}

			Console.WriteLine("Email successfully sent");
			Console.ReadKey();
		}
	}
}
