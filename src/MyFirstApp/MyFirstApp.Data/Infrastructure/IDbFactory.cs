using System;

namespace MyFirstApp.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        MyFirstAppContext Init();
    }
}