using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountCreator
{



    public interface IServer
    {

        string Serwer { get; }
        void Account_creator(string serwer, string email, string username, string password);

    }

}
