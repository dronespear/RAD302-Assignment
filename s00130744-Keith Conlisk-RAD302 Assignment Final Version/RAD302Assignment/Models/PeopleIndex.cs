using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RAD302Assignment.Models
{
    public class PeopleIndex
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
        //navigation to student
        public ICollection<PersonInfo> People { get; set; }
    }
}
