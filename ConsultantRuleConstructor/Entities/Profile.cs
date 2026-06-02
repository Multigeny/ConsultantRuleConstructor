using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantRuleConstructor.Entities
{
    internal class Profile
    {
        public int Id { get; set; }
        public List<ProfileProperties> profileProperties { get; set; } = [];
    }
}
