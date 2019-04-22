using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeopleSearchAPI.Models
{
    //The following class definition must match the field names of the database
    //for the correct information to be sent back to the front-end.
    public class Person
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string CityStateZip { get; set; }
        public string Interests { get; set; }
        public string PictureLocation { get; set; }
    }
}