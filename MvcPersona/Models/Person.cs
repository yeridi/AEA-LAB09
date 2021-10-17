using System;


namespace MvcPersona.Models
{
    public class Person
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }


        public bool IsTecsup { get; set; }
    }
}