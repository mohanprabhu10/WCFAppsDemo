using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new WebClient();
            var data= client.DownloadString("https://localhost:44330/api/Student");
            Console.WriteLine(data);
            //Downloading API will download the data as JSON object(basically a string) 
            //which can be used to read the data.....

        }
    }
}
