using System;
using Dapper;
using HomeWorkWithUsers.Data.Domain;
using HomeWorkWithUsers.Data.Repository;
using Npgsql;

namespace HomeWorkWithUsers.Data.Mocks
{
	public class UserMockRepository : IUserRepository {

        private readonly NpgsqlConnection connectionString;

        public UserMockRepository(string connectionString) {
            this.connectionString = new NpgsqlConnection(connectionString);
        }

        public void Create(User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsers() {
            var users = connectionString.Query<User>("SELECT \"Id\", \"Name\", \"SurName\", \"Phone\", \"Email\", \"CreateDate\", \"ParentId\" FROM public.\"Users\";").ToList();
            return users ?? new List<User>();

        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}

