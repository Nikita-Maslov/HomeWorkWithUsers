using System;
using AppDAL.EF;
using AppDAL.Entities;
using AppDAL.Interfaces;

namespace AppDAL.Repositories
{
	public class EFUnitOfWork : IUnitOfWork {

        private readonly AppDBContext db;
        private UserRepository? userRepository;
        private TaskRepository? taskRepository;

        public EFUnitOfWork(AppDBContext appDBContext)
		{
            db = appDBContext;
        }

        public IRepository<User> User {
            get {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public IRepository<MyTask> MyTask {
            get {
                if (taskRepository == null)
                    taskRepository = new TaskRepository(db);
                return taskRepository;
            }
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed) {
                if (disposing) {
                    db.Dispose();
                }
                this.disposed = true;
            }

        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

