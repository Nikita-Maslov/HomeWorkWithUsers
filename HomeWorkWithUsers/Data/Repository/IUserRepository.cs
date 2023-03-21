﻿using System;
using HomeWorkWithUsers.Data.Domain;

namespace HomeWorkWithUsers.Data.Repository {
	public interface IUserRepository {
        void Create(User user);
        void Delete(int id);
        User Get(int id);
        List<User> GetUsers();
        void Update(User user);
    }
}

