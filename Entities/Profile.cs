using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantRuleConstructor.Entities
{
    internal class Profile
    {
        public int Id { get; set; }
        public bool ResettlementProgramStatus { get; set; }
        public List<Document> RequiredDocuments { get; set; } = new List<Document>();
    }
}
