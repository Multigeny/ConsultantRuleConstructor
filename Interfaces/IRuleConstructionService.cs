using ConsultantRuleConstructor.Data;
using ConsultantRuleConstructor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantRuleConstructor.Interfaces
{
    internal interface IRuleConstructionService
    {
        int CreateRule(RuleDto ruleDto);
        RuleDto? GetById(int Id);
        List<RuleDto> GetAllRules();
    }
}
