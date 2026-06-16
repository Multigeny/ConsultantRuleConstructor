using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantRuleConstructor.Entities
{
    internal class Rule
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        public List<Document> Documents { get; set; } = [];

        public List<Profile> profiles { get; set; } = [];


        public List<Guide> Guids { get; set; } = [];



    }
}
