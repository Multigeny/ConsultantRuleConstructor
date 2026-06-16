using ConsultantRuleConstructor.Data;
using ConsultantRuleConstructor.Interfaces;
using Microsoft.EntityFrameworkCore;
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

            Rules = new RuleRepository(_context);
            Console.WriteLine(context.Database.CanConnect());
            _context.Database.Migrate();
            Console.WriteLine("Migration complete");
        }



        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}
