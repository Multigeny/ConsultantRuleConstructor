using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantRuleConstructor.Entities
{
    internal class ProfileProperties
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public int ProfileId {  get; set; }
        public Profile Profile { get; set; }
    }
}
