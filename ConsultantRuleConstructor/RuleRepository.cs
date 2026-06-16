using System;
using System.Collections.Generic;
using System.Text;
using ConsultantRuleConstructor.Data;
using ConsultantRuleConstructor.Entities;
using ConsultantRuleConstructor.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace ConsultantRuleConstructor
{
    internal class RuleRepository : IRuleRepository
    {
        private readonly AppDbContext _context;

        public RuleRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Rule rule)
        {
            _context.Rules.Add(rule);
        }

        public List<Rule> GetAll()
        {
            return _context.Rules
                .Include(r => r.Guids)
                    .ThenInclude(d => d.Organizations)
                .Include(r => r.Guids).ToList();
        }

        public Rule? GetById(int Id)
        {
            return _context.Rules
                .Include(r => r.Guids)
                    .ThenInclude(d => d.Organizations)
                .Include(r => r.Guids)
                .FirstOrDefault(r => r.Id == Id);

        }
    }
}
