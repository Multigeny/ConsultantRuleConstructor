using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantRuleConstructor.Interfaces
{
    internal interface IUnitOfWork
    {
        public IRuleRepository Rules { get; }

        int Complete();
    }
}
