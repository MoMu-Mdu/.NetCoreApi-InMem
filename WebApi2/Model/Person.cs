using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebApi2.Model
{
    [DataContract]
    public class Person
    {
        [DataMember(Name = "Id")]
        public int Id { get; set; }
        [DataMember(Name = "GivenName")]
        public string GivenName { get; set; }
        [DataMember(Name = "FamilyName")]
        public string FamilyName { get; set; }
        [DataMember(Name = "Age")]
        public int Age { get; set; }
        [DataMember(Name = "Address")]
        public string Address { get; set; }
    }
}
