using ConsultantRuleConstructor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantRuleConstructor.Interfaces
{
    internal interface IRuleConstructionService
    {
        int CreateRule(Rule rule);
        Rule? GetById(int Id);
        List<Rule> GetAllRules();
    }
}
