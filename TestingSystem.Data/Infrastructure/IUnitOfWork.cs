using System;

namespace TestingSystem.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
