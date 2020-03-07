using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_jedn
{
    public class Konwerter
    {
        public void CtoF()
        {
            double F, C;
            Console.WriteLine("Podaj temperature w C");
            C=int.Parse(Console.ReadLine());
            F = (C*1.8f)+32f;
            Console.WriteLine("To jest " + F + " stopni Fahrenheita");
        }

        public void FtoC()
        {
            double F, C;
            Console.WriteLine("Podaj temperature w F");
            F=int.Parse(Console.ReadLine());
            C = (F-32f)/1.8f;
            Console.WriteLine("To jest " + C + " stopni Celsjusza");
        }

        public void KmtoM()
        {
            double Km = 0, M = 0;
            Console.WriteLine("Podaj odleglosc w kilometrach");
            Km=int.Parse(Console.ReadLine());
            M=Km/1.609344;
            Console.WriteLine("To jest " + M + " mil");
        }

        public void MtoKm()
        {
            double M = 0, Km = 0;
            Console.WriteLine("Podaj odleglosc w milach");
            M=int.Parse(Console.ReadLine());
            Km=M*1.609344;
            Console.WriteLine("To jest " + Km + " kilometrow");
        }

        public void KgtoF()
        {
            double Kg = 0, F = 0;
            Console.WriteLine("Podaj wage w kilogramach");
            Kg=int.Parse(Console.ReadLine());
            F=Kg*2.2046f;
            Console.WriteLine("To jest " + F + " funtow");
        }

        public void FtoKg()
        {
            double Kg = 0, F = 0;
            Console.WriteLine("Podaj wage w funtach");
            F=int.Parse(Console.ReadLine());
            Kg= F/2.2046f;
            Console.WriteLine("To jest " + Kg + " kilogramow");
        }
    }
}
