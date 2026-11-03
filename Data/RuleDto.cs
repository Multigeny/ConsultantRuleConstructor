using ConsultantRuleConstructor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantRuleConstructor.Data
{
    internal class RuleDto
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = "";
        public bool ResettlementProgramStatus { get; set; }
        public List<DocumentDto> Documents { get; set; } = [];
        public GuideDto? Guide { get; set; } = null;
    }
}
