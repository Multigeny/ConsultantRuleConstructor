using ConsultantRuleConstructor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantRuleConstructor.Interfaces
{
    internal interface IRuleRepository
    {
        public void Add(Rule rule);
        public Rule? GetById(int Id);
        public List<Rule> GetAll();
    }
}
