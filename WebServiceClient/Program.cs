using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceClient.MyWebServices;
using System.Data;

namespace WebServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            EmpDataService empData = new EmpDataService();
            var data = empData.GetAllRecords();
            var table = data.Tables[0];
            foreach (DataRow row in table.Rows)
                Console.WriteLine(row["EmpName"]);
        }
    }
}
