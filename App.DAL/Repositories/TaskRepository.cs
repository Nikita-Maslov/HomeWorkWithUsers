using System;
using AppDAL.EF;
using AppDAL.Entities;
using AppDAL.Interfaces;

namespace AppDAL.Repositories {
    public class TaskRepository : IRepository<MyTask> {

        private readonly AppDBContext db;

        public TaskRepository(AppDBContext appDBContext) {
            db = appDBContext;
        }

        public void Create(MyTask item) {
            if (GetAll().Count() != 0) {
                item.Id = db.Tasks.Max(u => u.Id) + 1;
            } 
            db.Tasks.Add(item);
        }

        public void Delete(int id) {
            throw new NotImplementedException();
        }

        public void Delete(MyTask item)
        {
            if (item != null) {
                db.Tasks.Remove(item);
            }
        }

        public IEnumerable<MyTask> Find(Func<MyTask, bool> predicate) {
            throw new NotImplementedException();
        }

        public MyTask Get(int id) {
            throw new NotImplementedException();
        }

        public IEnumerable<MyTask> GetAll() {
            return db.Tasks.OrderBy(task => task.Id).Where(t => t != null).ToList();
        }

        public IEnumerable<MyTask> GetItemsForListView(int skip, int size) {
            return db.Tasks
                .OrderBy(task => task.Id)
                .Where(t => t.Id>skip)
                .Take(10)
                .ToList();
        }

        public void Update(MyTask item) {
            if (item != null) {
                db.Tasks.Update(item);
            }
        }
    }
}

