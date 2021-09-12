using System;

namespace Entities.DataTransferObjects
{
    public class PersonForCreationDto
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string Birth_Date { get; set; }
        public string Phone_Number { get; set; }
    }
}