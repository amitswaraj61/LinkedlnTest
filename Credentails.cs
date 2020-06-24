using Newtonsoft.Json;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedinApp
{
   public class Credentails
    {
        public string email = "";
        public string password = "";
        public string json = "";

        public  Credentails()
        {
            using (StreamReader r = new StreamReader("C:\\Users\\Kis\\source\\repos\\LinkedinApp\\LinkedinApp\\amit.json"))
            {
                json = r.ReadToEnd();
            }

            dynamic array = JsonConvert.DeserializeObject(json);
            Console.WriteLine("Array::::" + array["email"]);
            email = array["email"];
            password = array["password"];
        }
    }
}