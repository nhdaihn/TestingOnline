using System;

namespace TestingSystem.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        TestingSystemEntities Init();
    }
}
