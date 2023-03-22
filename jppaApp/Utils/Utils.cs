using System;
using System.Collections.Generic;
using System.Text;

namespace jppaApp.Utils
{
    public class Utils
    {
        /* Nombre: Juan Pablo Palma Apoderado No.Control: 1221100259 */
        public const string API_URL = "http://172.16.2.43:3000/api" ; 
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
