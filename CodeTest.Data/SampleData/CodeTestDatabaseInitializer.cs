using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CodeTest.Model;

namespace CodeTest.Data.SampleData
{
    public class CodeTestDatabaseInitializer : DropCreateDatabaseIfModelChanges<CodeTestDbContext>
    {
        protected override void Seed(CodeTestDbContext context)
        {
            var m = new Message() 
            { 
               Text ="This is a message.",
               Owner = new Person()
               {
                    FirstName = "Andreas",
                    LastName = "Fransson",
                    Email = "andreas.fransson@gmail.com"
               },
               DateCreated =  DateTime.Now
            };
            context.Messages.Add(m);
            context.SaveChanges();            
        }
    }
}
