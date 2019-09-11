﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleWebApi.Models
{
    public class Employee
    {
        //This is our Entity class that will be used to share among our clients.
        //The Entity class auto generated by the EF is not recommended to be shared to the client.
        //Instead 
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }

        public EmpTable Convert()
        {
            return new EmpTable
            {
                EmpID = this.ID,
                EmpName= Name,
                EmpAddress= Address,
                EmpSalary= Salary
            };
        }

        public void Convert(EmpTable record)
        {
            ID = record.EmpID;
            Name = record.EmpName;
            Address = record.EmpAddress;
            Salary = record.EmpSalary;
        }
    }
}