using System;
using System.Numerics;
using AppDAL.Entities;

namespace AppDAL.Interfaces
{
    public interface IUnitOfWork : IDisposable {
        IRepository<User> User { get; }
        IRepository<MyTask> MyTask { get; }
        void Save();
    }
}

