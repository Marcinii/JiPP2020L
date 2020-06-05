using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountCreator
{
   public class ServersService
    {
        public List<IServer> GetServers()
        {
            return new List<IServer>()
            {
                new EUWAccountCreatorLogic(),
                new EUNEAccountCreatorLogic()
            };



        }



    }
}
