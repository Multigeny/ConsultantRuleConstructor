using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantRuleConstructor.Entities
{
    internal class Rule
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public Document Document { get; set; }


        public Guide Guide { get; set; }



    }
}
