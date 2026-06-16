using ConsultantRuleConstructor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantRuleConstructor
{
    internal class RuleBuilder
    {
        public Rule _rule = new Rule();


        // Добавляем документы
        public RuleBuilder addTargetDocument(Document document)
        {
            _rule.Documents.Add(document);
            return this;
        }


        public RuleBuilder AddProfile(Profile profile)
        {
            _rule.profiles.Add(profile);
            return this;
        }


        public RuleBuilder SetName(string name)
        {
            _rule.Name = name;
            return this;
        }
       


        public RuleBuilder addGuide(Guide guide)
        {
            _rule.Guids.Add(guide);
            return this;
        }

        public Rule Build()
        {

            return _rule;
        }

    }
}
