using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CodeTest.Data.SampleData
{
    public class CodeTestDatabaseInitializer : DropCreateDatabaseIfModelChanges<CodeTestDbContext>
    {
        protected override void Seed(CodeTestDbContext context)
        {            
            base.Seed(context);
        }
    }
}
