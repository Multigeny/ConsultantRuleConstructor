using System;
using System.Collections.Generic;
using System.Text;
using ConsultantRuleConstructor.Entities;
using ConsultantRuleConstructor.Interfaces;

namespace ConsultantRuleConstructor
{
    internal class RuleConstructionService : IRuleConstructionService
    {
        private readonly IUnitOfWork _uow;

        public RuleConstructionService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public int addRule(Rule rule)
        {
            _uow.Rules.Add(rule);
            _uow.Complete();
            return rule.Id;
        }

        public List<Rule> GetAllRules()
        {
            return _uow.Rules.GetAll();
        }

        public Rule? GetById(int Id)
        {
            return _uow.Rules.GetById(Id);
        }
    }
}
