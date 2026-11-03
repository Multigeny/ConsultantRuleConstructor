using ConsultantRuleConstructor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantRuleConstructor
{
    internal class RuleBuilder
    {
        private readonly Rule _rule = new();

        public RuleBuilder SetName(string name)
        {
            _rule.Name = name;
            return this;
        }

        public RuleBuilder SetDocuments(IEnumerable<Document> documents)
        {
            _rule.Documents = documents.ToList();
            return this;
        }
        public RuleBuilder SetGuide(Guide guide)
        {
            _rule.Guide = guide;
            return this;
        }

        public RuleBuilder setResettlementProgramStatus(bool ResettlementProgramStatus)
        {
            _rule.ResettlementProgramStatus = ResettlementProgramStatus;
            return this;
        }

        public Rule Build()
        {
            return _rule;
        }

    }
}
