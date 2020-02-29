using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter
{
	class Program
	{
		static void Main(string[] args)
		{
			//conversion from Fahrenheit to Celsius
			Console.WriteLine("Fahrenheit to Celsius: ");
			int fah = int.Parse(Console.ReadLine());
			Console.WriteLine();

			//conversion formula from F to C

			int FtoC = ((fah - 32) / 9) * 5;
			Console.WriteLine("Celsius is {0}:", FtoC);
			Console.ReadLine();

			//conversion from Celsius to Fahrenheit
			Console.WriteLine("Celsius to Fahrenheit: ");
			int cel = int.Parse(Console.ReadLine());
			Console.WriteLine();

			//conversion from C to F
			int CtoF = ((cel * 9) / 5) + 32;
			Console.WriteLine("Fahrenheit is {0}: ", CtoF);
			Console.ReadLine();

			//conversion from Kilometers to Miles
			Console.WriteLine("Kilometers to Miles: ");
			int km = int.Parse(Console.ReadLine());
			Console.WriteLine();

			//conversion formula from km to mi
			double KmtoMi = km * 0.62;
			Console.WriteLine("Miles is {0}: ", KmtoMi);
			Console.ReadLine();

			//conversion from Miles to Kilometers
			Console.WriteLine("Miles to Kilometers: ");
			int mi = int.Parse(Console.ReadLine());
			Console.WriteLine();

			//conversion formula from mi to km
			double MitoKm = mi * 1.609;
			Console.WriteLine("Kilometers is{0}: ", MitoKm);
			Console.ReadLine();

			//convesion from Pounds to Kilograms
			Console.WriteLine("Pounds to Kilograms: ");
			int pounds = int.Parse(Console.ReadLine());
			Console.WriteLine();

			//conversion formula from pounds to kg
			double PoundstoKg = pounds * 0.45;
			Console.WriteLine("Kilogram is{0}: ", PoundstoKg);
			Console.ReadLine();

			//conversion from Kilograms to Pounds
			Console.WriteLine("Kilograms to Pounds: ");
			int kg = int.Parse(Console.ReadLine());
			Console.WriteLine();

			//conversion formula from kg to pounds
			double KgtoPounds = kg * 2.204;
			Console.WriteLine("Pounds is{0}: ", KgtoPounds);
			Console.ReadLine();





		}
	}
}
