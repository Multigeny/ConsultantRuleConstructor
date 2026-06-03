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

        public RuleBuilder AddProfile(Profile profile)
        {
            _rule.profiles.Add(profile);
            return this;
        }

        public RuleBuilder SetDocument(Document document)
        {
            _rule.Document = document;
            return this;
        }
        public RuleBuilder SetGuide(Guide guide)
        {
            _rule.Guide = guide;
            return this;
        }

        public Rule Build()
        {
            return _rule;
        }

    }
}
