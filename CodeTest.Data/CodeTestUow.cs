using CodeTest.Data.Contracts;
using CodeTest.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Data
{
    public class CodeTestUow : ICodeTestUow, IDisposable
    {
        public CodeTestUow(IRepositoryProvider repositoryProvider)
        {
            CreateDbContext();
            repositoryProvider.DbContext = DbContext;
            RepositoryProvider = repositoryProvider;
        }

        public IRepository<Message> Messages { get { return GetRepository<Message>(); } }
        public IRepository<Person> Persons { get { return GetRepository<Person>(); } }

        protected void CreateDbContext()
        {
            DbContext = new CodeTestDbContext();
            
            DbContext.Configuration.ProxyCreationEnabled = false;            
            DbContext.Configuration.LazyLoadingEnabled = false;
            DbContext.Configuration.ValidateOnSaveEnabled = false;
        }
        
        public void Commit()
        {        
            DbContext.SaveChanges();
        }

        private CodeTestDbContext DbContext { get; set; }


        protected IRepositoryProvider RepositoryProvider { get; set; }

        private IRepository<T> GetRepository<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();
                }
            }
        }
    }
}
