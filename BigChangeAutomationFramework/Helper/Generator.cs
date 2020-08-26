using System;
using System.Collections.Generic;
using System.Text;

namespace BigChangeAutomationFramework.Helper
{
    public class Generator : IGenerator
    {
        public string GetRandomString()
        {
            string SALTCHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder salt = new StringBuilder();
            Random rnd = new Random();
            while (salt.Length < 10)
            {
                int index = (int)(rnd.NextDouble() * SALTCHARS.Length);
                salt.Append(SALTCHARS[index]);
            }
            string saltStr = salt.ToString();
            return saltStr;
        }
    }
}
