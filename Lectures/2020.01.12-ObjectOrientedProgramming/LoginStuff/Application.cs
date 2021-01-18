using System;

namespace LoginStuff
{
    public class Application
    {
        readonly (string UserName,string Password)[] CredentialData = new (string UserName, string Password)[]
        {
            (UserName: "Inigo.Montoya", Password: "OpenSaysMe"),
            (UserName: "Princess.Buttercup", Password: "RealPassword" ),
            (UserName: "Prince.Humperdink", Password: "Another Real Password" )
        };

        public Application()
        {
            // (string, int, double) tuple = ("Harry", 1, 1.0);
            // String text1;
            // string text2;
        }

        public bool Login(string userName, string password)
        {
            foreach((string itemUserName, string itemPassword) in CredentialData)
            {
                if((userName == itemUserName) && (password == itemPassword))
                {
                    return true;
                }
            }
            return false;
        }
    }
}