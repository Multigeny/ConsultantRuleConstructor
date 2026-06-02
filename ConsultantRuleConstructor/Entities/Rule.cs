using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantRuleConstructor.Entities
{
    internal class Rule
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public Document Document { get; set; }
        public int DocumentId { get; set; }


        public Guide Guide { get; set; }
        public int GuideId { get; set; }

        public Condition Condition { get; set; }
        public int ConditionId { get; set; }

    }
}
