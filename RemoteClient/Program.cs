using System;
using RemoteLib;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace RemoteClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelServices.RegisterChannel(new TcpChannel(), false);
            Messenger proxy = Activator.GetObject(typeof(Messenger), 
                "tcp://161.85.93.183:1234/MsgServices") as Messenger;//Unbox....
            if (proxy == null)
            {
                Console.WriteLine("Failed to create the service");
                return;
            }
            Console.WriteLine("Please enter the username");
            string user = Console.ReadLine();
            do
            {
                Console.WriteLine("post UR message here.....");
                string msg = Console.ReadLine();
                proxy.PostMessage(user, msg);
            } while (true);
        }
    }
}

// Remoting Limitations:
//Both the clients and the server should be .NET Apps in Remoting.
//Other Protocols like SOAP are not possible in Remoting. The data will be in .NET type but not JSON or XML.
//If aservice created in .NET has to be consumed by a Java program, it can't be done using .NET Remoting technology.
//Use XML Web services for making the service cross platform.
