using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantRuleConstructor.Entities
{
    internal class Rule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Document TargetDocument { get; set; }
        public Guide Guide { get; set; }
        public bool ResettlementProgramStatus { get; set; }
    }
}
