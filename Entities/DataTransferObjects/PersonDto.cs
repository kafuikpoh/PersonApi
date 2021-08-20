using System;

namespace Entities.DataTransferObjects
{
    public class PersonDto
    {
        public int Person_Id { get; set; }
        public string FullName { get; set; }
        public string Birth_Date { get; set; }
        public string Phone_Number { get; set; }
        
    }
}