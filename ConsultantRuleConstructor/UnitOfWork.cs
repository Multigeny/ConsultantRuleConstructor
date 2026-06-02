using ConsultantRuleConstructor.Data;
using ConsultantRuleConstructor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantRuleConstructor
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IRuleRepository Rules { get; }


        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            Rules = new RuleRepository(context);
        }



        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}
