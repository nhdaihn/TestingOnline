using System;

namespace TestingSystem.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        TestingSystemEntities dbContext;

        public TestingSystemEntities Init()
        {
            return dbContext ?? (dbContext = new TestingSystemEntities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
