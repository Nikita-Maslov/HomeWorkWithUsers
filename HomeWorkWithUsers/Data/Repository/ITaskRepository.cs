using System;
using HomeWorkWithUsers.Data.Domain;

namespace HomeWorkWithUsers.Data.Repository {

    public interface ITaskRepository {
        void Create(MyTask item);
        String Delete(int id);
        MyTask Get(int id);
        List<MyTask> GetTasks();
        void Update(MyTask item);
    }
}

