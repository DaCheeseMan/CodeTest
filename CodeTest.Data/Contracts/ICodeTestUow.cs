using CodeTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Data.Contracts
{
    public interface ICodeTestUow
    {
        void Commit();

        IRepository<Message> Messages { get; }
    }
}
