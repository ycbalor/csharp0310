using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LinqTest
{
	class Program
	{
		//1번
		//static void Main(string[] args)
		//{
		//	int[] num = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

		//	var onjQuery1 = from n in num
		//					where n % 2 == 1
		//					orderby n
		//					select n;

		//	foreach (int i in onjQuery1)
		//	{
		//		Console.WriteLine("홀수 :{0}", i);
		//	}

		//	// 원래는 이타입으로 받아야함
		//	IEnumerable<int> onjQuery2 = from n in num
		//								 where n > 3
		//								 orderby n descending
		//								 select n;

		//	foreach (int i in onjQuery2)
		//	{
		//		Console.WriteLine(i);
		//	}
		//}


		// 2번
		//static void Main()
		//{
		//	int[] numbers = { 1, 2, 3, 4, 5, 6 };

		//	// 메소드기반 쿼리식, 짝수를 내림차순 정렬하여 출력
		//	IEnumerable<int> q1 = numbers.Where(num => num % 2 == 0).OrderByDescending(n => n);

		//	foreach (int i in q1)
		//		Console.WriteLine(i);

		//	// 메소드 기반 쿼리식, 짝수의 합
		//	int sum = numbers.Where(num => num % 2 == 0).Sum();
		//	Console.WriteLine("Sum = " + sum);

		//	// 최대 값
		//	int max = numbers.Where(num => num % 2 == 0).Max();
		//	Console.WriteLine("Max = " + max);

		//	// 최대 값
		//	double average = numbers.Where(num => num % 2 == 0).Average();
		//	Console.WriteLine("Average = " + average);

		//	// Aggregate 주어진 연산의 결과를 포워드 하면서 진행된다.
		//	// 1 * 2 한 후 결과를 3과 곱하고 다시 결과를 4와 곱함
		//	var result = numbers.Aggregate((a, b) => a * b);
		//	Console.WriteLine("Aggregation =" + result);

		//	// 10은 SEED, 10 + 1 결과를 2와 더하고 다시 결과를 3과 더함..
		//	result = numbers.Aggregate(10, (a, b) => a + b);
		//	Console.WriteLine("Aggregation with seed =" + result);

		//	// 짝수를 대상으로 2 * 4 한 후 결과를 6과 곱하고..
		//	result = numbers.Where(num => num % 2 == 0).Aggregate((a, b) => a * b);
		//	Console.WriteLine("Aggregation.Where =" + result);
		//}

		//3번
		static bool isEven(int num)
		{
			return num % 2 == 0;
		}

		static void Main()
		{
			int[] numbers = { 1, 2, 3, 4, 5, 6 };

			// 원래 이렇게 사용해야함
			//IEnumerable<int> q1 = numbers.Where(new Func<int, bool>(isEven)).OrderByDescending(n => n);

			// new를 생략할 수 있기 때문에
			IEnumerable<int> q1 = numbers.Where(n => n % 2 == 0).OrderByDescending(n => n);

			// 메소드기반 쿼리식, 짝수를 내림차순 정렬하여 출력
			//IEnumerable<int> q1 = numbers.Where(isEven).OrderByDescending(n => n);

			foreach (int i in q1)
				Console.WriteLine(i);

			// 메소드 기반 쿼리식, 짝수의 합
			int sum = numbers.Where(num => num % 2 == 0).Sum();
			Console.WriteLine("Sum = " + sum);

			// 최대 값
			int max = numbers.Where(num => num % 2 == 0).Max();
			Console.WriteLine("Max = " + max);

			// 최대 값
			double average = numbers.Where(num => num % 2 == 0).Average();
			Console.WriteLine("Average = " + average);

			// Aggregate 주어진 연산의 결과를 포워드 하면서 진행된다.
			// 1 * 2 한 후 결과를 3과 곱하고 다시 결과를 4와 곱함
			var result = numbers.Aggregate((a, b) => a * b);
			Console.WriteLine("Aggregation =" + result);

			// 10은 SEED, 10 + 1 결과를 2와 더하고 다시 결과를 3과 더함..
			result = numbers.Aggregate(10, (a, b) => a + b);
			Console.WriteLine("Aggregation with seed =" + result);

			// 짝수를 대상으로 2 * 4 한 후 결과를 6과 곱하고..
			result = numbers.Where(num => num % 2 == 0).Aggregate((a, b) => a * b);
			Console.WriteLine("Aggregation.Where =" + result);
		}
	}
}
