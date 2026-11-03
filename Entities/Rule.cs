using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantRuleConstructor.Entities
{
    internal class Rule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Document> Documents { get; set; } = [];
        public Guide Guide { get; set; }
        public bool ResettlementProgramStatus { get; set; }
    }
}
