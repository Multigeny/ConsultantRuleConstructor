using ConsultantRuleConstructor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantRuleConstructor.Interfaces
{
    internal interface IRuleConstructionService
    {
        int addRule(Rule rule);
        Rule? GetById(int Id);
        List<Rule> GetAllRules();
    }
}
