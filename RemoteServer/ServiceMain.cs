using System;
using RemoteLib; //Our component that will be created remotely.
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
//U add the reference of the System.Runtime.Remoting Dll to get the namespaces and the classes required for .NET Remoting Application.

//Add the reference of the RemoteLib that was created earlier. The instances of the messenger will be created in this server application.
namespace RemoteServer
{
    //.NET Remoting allows the service accessible through 2 protocols: TCP and HTTP.
    //TCP channel is used for Intranet kind of apps and HTTP for Internet kind of apps.
    // Every service based app needs the following things:
    //An address thro which Clients can access ur service.
    //A protocol which contains info on how the service is available.
    //A PortNo thro which the service is accessible.
    class ServiceMain
    {
        static void Main(string[] args)
        {
            //U should create the TcpServer object.
            TcpServerChannel server = new TcpServerChannel(1234);
            //Register the Tcp channel to the Windows services.
            ChannelServices.RegisterChannel(server, false);
            //Register the service into the Windows OS.
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(Messenger), "MsgServices", 
                WellKnownObjectMode.Singleton);  //only one instance of the object
            //will be made available for the clients...
            //Explore the service to client(Run the Application)
            Console.WriteLine("server is ready at http://localhost/MsgServices");
            Console.WriteLine("Press any key to terminate the service");
            Console.ReadKey();
        }
    }
}
