using ConsultantRuleConstructor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantRuleConstructor.Data
{
    internal class GuideDto
    {
        public int Id { get; set; }
        public string Message { get; set; } = "";
        public string Refuse { get; set; } = "";
        public List<OrganizationDto> Organizations { get; set; } = new List<OrganizationDto>();
    }
}
