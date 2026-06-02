using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantRuleConstructor.Entities
{
    internal class Document
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Organization> Organizations { get; set; } = [];
    }
}
