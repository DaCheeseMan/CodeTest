using CodeTest.Data.SampleData;
using CodeTest.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CodeTest.Data
{
    public class CodeTestDbContext : DbContext
    {
        public CodeTestDbContext()
            : base(nameOrConnectionString: "CodeTest") { }        

        public DbSet<Message> Messages { get; set; }
        public DbSet<Person> Persons { get; set; }

        static CodeTestDbContext()
        {
            Database.SetInitializer(new CodeTestDatabaseInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();            
        }
    }
}
