using System;
using AppDAL.Interfaces;
using System.Numerics;
using AppDAL.Entities;
using AppDAL.EF;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AppDAL.Repositories
{
	public class UserRepository : IRepository<User> {

        private readonly AppDBContext db;

        public UserRepository(AppDBContext appDBContext)
		{
            db = appDBContext;

        }

        public void Create(User item)
        {
            item.CreateDate = DateTimeOffset.UtcNow.ToString();
            if (GetAll().Count() != 0) {
                item.Id = db.Users.Max(u => u.Id) + 1;
            }
            db.Users.Add(item);
        }

        public void Delete(User item)
        {
            if (item!= null) {
                db.Users.Remove(item);
            }
        }

        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            var users = db.Users.Where(p => p!=null).ToList();
            User user = null;
            foreach (User item in users ) {
                if (item.Id == id) {
                   user = item;
                }
            }
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            
            return db.Users.OrderBy(user => user.Id).Where(u => u!=null).ToList();
        }

        public IEnumerable<User> GetTasksForListView(int skip, int size)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetItemsForListView(int skip, int size)
        {
            return db.Users
                .OrderBy(users => users.Id)
                .Where(t => t.Id > skip)
                .Take(10)
                .ToList();
        }

        public void Update(User item)
        {  
            if (item != null) {
                item.CreateDate = DateTimeOffset.UtcNow.ToString();
                db.Users.Update(item);
            }
        }
    }
}

