using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.IO;

//The important libraries of WCF are: ServiceModel and System.Runtime.Serialization. 
//It must reference these libraries before u develop any wcf app.
// Self hosting apps are created for developing WCF components that are to be consumed by other .NET apps within the Intranet network. 
// In other words, u will develop the code for hosting a Wcf component inside ur .NET app like the way we used to do in .NET Remoting kind of apps.
// Add the references of the above libraries into ur project as this is a console app.

namespace WcfSelfHostingApp
{
    //Like any other WCF components, U need to develop the service contracts and its implementation in the form of a WCF components.
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        List<Customer> GetAllCustomers();
    }
    [ServiceContract]
    public interface ICustomerAddingService
    {
        [OperationContract]
        void AddNewCustomer(Customer cst);
    }

    [DataContract]//This performs the serialization for ur data components....
    public class Customer
    {
        [DataMember] public int CustomerID { get; set; }
        [DataMember] public string CustomerName { get; set; }
        [DataMember] public string CustomerAddress { get; set; }
        [DataMember] public long CustomerPhone { get; set; }
    }

    public class WCFComponent : ICustomerService, ICustomerAddingService
    {
        public void AddNewCustomer(Customer cst)
        {
            var list = GetAllCustomers();
            list.Add(cst);
            var content = JsonConvert.SerializeObject(list);
            using (StreamWriter writer = new StreamWriter("Customer.json")) 
            {
                writer.WriteLine(content);
            }
        }

        public List<Customer> GetAllCustomers()
        {
            var reader = new StreamReader("Customer.json");
            string content = reader.ReadToEnd();
            var data = JsonConvert.DeserializeObject(content, typeof(List<Customer>));
            if (data is List<Customer>)
                return data as List<Customer>;
            else
                throw new FaultException("Failed to load the Json file");
        }
    }
    class Program
    {
        static List<Customer> getRecords()
        {
            var reader = new StreamReader("Customer.json");
            string content = reader.ReadToEnd();
            var data = JsonConvert.DeserializeObject(content, typeof(List<Customer>));
            if (data is List<Customer>)
                return data as List<Customer>;
            else
                return null;
        }
        static void Main(string[] args)
        {
            //WriteToJson();
            //readRecords();
            //Code to Host the service....
            string uri = "http://localhost:1234/MySelfHostingServices/";
            try
            {
                ServiceHost hostApp = new ServiceHost(typeof(WCFComponent), new Uri(uri));
                WSHttpBinding binding = new WSHttpBinding();
                Type contract = typeof(ICustomerService);
                hostApp.AddServiceEndpoint(contract, binding, "");
                hostApp.Open();
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                hostApp.Close();
            }
            catch (CommunicationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception genEx)
            {
                Console.WriteLine(genEx.Message);
            }
        }

        private static void readRecords()
        {
            throw new NotImplementedException();
        }

        private static void WriteToJson()
        {
            throw new NotImplementedException();
        }
    }
}
