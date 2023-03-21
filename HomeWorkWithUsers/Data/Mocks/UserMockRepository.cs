using System;
using System.Collections.Generic;
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
            user.CreateDate = DateTimeOffset.UtcNow.ToString(); ;
            var query = $"INSERT INTO public.\"Users\"(\"Name\", \"SurName\", \"Phone\", \"Email\", \"CreateDate\", \"ParentId\")"+
                $"VALUES('{user.Name}', '{user.SurName}', '{user.Phone}', '{user.Email}', '{user.CreateDate}', {user.ParentId});";
            user.Id = connectionString.ExecuteScalar<int>(query);
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

