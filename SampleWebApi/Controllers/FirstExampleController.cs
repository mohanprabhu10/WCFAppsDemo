using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SampleWebApi.Models;

//All WebAPIs are derived from System.Web.http.ApiController which internally implements an interface called IController which is the foundation for all MVC based Apps in ASP .NET.
//Web Apis are improvised versions of Service based Architecture, future of WCF.
//Some Apps which are migrating to web API from WCF, will create ApiControllers which internally refer to the WCF Components.

namespace SampleWebApi.Controllers
{
    public class FirstExampleController : ApiController
    {
        public string GetWelcomeMessage()
        {
            return "Hello World from Web Api";
        }
        //GET passing an argument within the URL(QueryString).....
        public string GetInputExample(int id)
        {
            return id + " was passed as an argument";
        }
        [Route("api/Customer/{id}")]
        public string GetInputExample2(int no)
        {
            return no + " was passed ";
        }
        [Route("api/Student")]
        public Student GetStudent()
        {
            return new Student
            {
                StudentNo = 111,
                CurrentClass = 2,
                StudentName = "Ankit",
                TotalMarks = 100
            };
        }
    }
}
