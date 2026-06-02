using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantRuleConstructor.Entities
{
    internal class Condition
    {
        public int Id { get; set; }
        public string PropertyKey { get; set; }
        public string Operator { get; set; }
        public string Value { get; set; }
    }
}
