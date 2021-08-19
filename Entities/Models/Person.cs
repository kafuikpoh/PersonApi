using System;
namespace Entities.Models
{
    public class Person
    {
        public int Person_Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public DateTime Birth_Date { get; set; }
        public string Phone_Number { get; set; }
    }
}
