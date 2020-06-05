using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountCreator;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            IList<IServer> serwers = new List<IServer>() {
                new EUWAccountCreatorLogic(),
                new EUNEAccountCreatorLogic()
};
          


            
           
        }
    }
}
