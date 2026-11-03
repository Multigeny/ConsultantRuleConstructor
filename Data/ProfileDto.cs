using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantRuleConstructor.Data
{
    internal class ProfileDto
    {
        public int Id { get; set; } = 0;
        public bool ResettlementProgramStatus { get; set; } = false;
        public List<DocumentDto> RequiredDocuments { get; set; } = new List<DocumentDto>();
    }
}
