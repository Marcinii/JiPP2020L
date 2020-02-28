using System;

public class Program
{
    public static void Main()
    {
        Console.Write("wprowadz wartosc do zamiany");
        double wartosc = double.Parse(Console.ReadLine());
        Console.Write("wybierz zamiane: {1.} c to f  | {2.} f to c  | {3.} km to m  | {4.} m to km  | {5.} kg to f  | {6.} f to kg ");
        int l = int.Parse(Console.ReadLine());

        switch (l)
        {
            case 1:
                Console.WriteLine(wartosc + " celcjusz " + "rowna sie farenhait = {0}", (wartosc * 1.8) + 32);
                break;
            case 2:

                Console.Write(wartosc + " farenhait " + "rowna sie celcjuszy ={0}", (wartosc - 32) * 5 / 9);
                break;
            case 3:

                Console.Write(wartosc + " kilometrow " + "rowna sie mil ={0}", wartosc * 1.6);
                break;
            case 4:
                Console.Write(wartosc + " mil " + "rowna sie kilometrow ={0}", wartosc / 1.6);

                break;
            case 5:
                Console.Write(wartosc + "  kilogramow " + "rowna sie funtow ={0}", wartosc * 0.4535);

                break;
            case 6:
                Console.Write(wartosc + " funtow " + "rowna sie kilogramow={0}", wartosc / 0.4535);

                break;

        }
    }
}