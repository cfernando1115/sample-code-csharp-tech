using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCodeTech
{
    class Person
    {
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }

        protected int Age;

        protected ILogger Logger;

        public Person(ILogger logger)
        {
            Logger = logger;
        }

        public Person(string name, DateTime birthdate, ILogger logger)
            :this(logger)
        {
            Name = name;
            Birthdate = birthdate;
        }

        public void CalculateAge()
        {
            var year = DateTime.Now.Year;
            Age = (DateTime.Now - Birthdate).Days/365;
            Logger.Log(Name + " is " + Age + " years old.");
        }
    }
}
