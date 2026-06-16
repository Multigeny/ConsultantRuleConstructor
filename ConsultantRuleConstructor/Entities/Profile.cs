using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantRuleConstructor.Entities
{
    internal class Profile
    {
        public int Id { get; set; }
        public bool resettlementStatus { get; set; }
        public List<Document> requiredDocuments { get; set; } = [];
    }
}
