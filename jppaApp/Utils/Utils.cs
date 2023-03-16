using System;
using System.Collections.Generic;
using System.Text;

namespace jppaApp.Utils
{
    public class Utils
    {
        public const string API_URL = "http://172.16.2.160:3000/api" ; 
        private readonly static Utils _instance = new Utils();
        public static Utils Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}
