using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RAD302Assignment.Models
{
    public class PersonInfo
    {
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; }
        public string Job { get; set; }
        //navigation to PeopleIndex
        public PeopleIndex BasicInformation { get; set; }
    }
}