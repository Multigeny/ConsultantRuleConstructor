using ConsultantRuleConstructor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantRuleConstructor
{
    internal class RuleEvaluator
    {
        public List<Rule> Evaluate(Profile profile, List<Rule> rules)
        {
            var result = new List<Rule>();

            foreach (var rule in rules)
            {
                if (IsMatch(profile, rule.Condition))
                {
                    result.Add(rule);
                }
            }

            return result;
        }

        private bool IsMatch(Profile profile, Condition condition)
        {
            var property = profile.profileProperties
                .FirstOrDefault(p => p.Name == condition.PropertyKey);

            if (property == null)
                return false;

            return Compare(
                property.Value,
                condition.Operator,
                condition.Value);
        }

        private bool Compare(string left, string op, string right)
        {
            return op switch
            {
                "==" => left == right,
                "!=" => left != right,
                _ => false
            };
        }
    }
}
