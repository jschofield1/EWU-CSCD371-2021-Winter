using System;

namespace LoginStuff
{
    public class Application
    {
        public Application()
        {


        }

        public bool Login(string userName, string password)
        {
            return password == "OpenSaysMe";
        }
    }
}