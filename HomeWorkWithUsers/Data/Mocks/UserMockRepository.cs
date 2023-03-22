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
            user.Id = connectionString.ExecuteScalar<int>("SELECT max(\"Id\") FROM public.\"Users\"");
            user.CreateDate = DateTimeOffset.UtcNow.ToString();
            var query = $"INSERT INTO public.\"Users\"(\"Id\", \"Name\", \"SurName\", \"Phone\", \"Email\", \"CreateDate\", \"ParentId\")" +
                $"VALUES('{(user.Id)+1}','{user.Name}', '{user.SurName}', '{user.Phone}', '{user.Email}', '{user.CreateDate}', {user.ParentId});";
            connectionString.Execute(query);
        }

        public String Delete(int id)
        {
            String s;
            var query = "DELETE FROM public.\"Users\" WHERE \"Id\"" +$" = {id};";
            try {
                var result = connectionString.Execute(query);
                s= "запрос выполнен";
            }
            catch{
                s = "";
            }
            return s;
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsers() {
            var users = connectionString.Query<User>("SELECT \"Id\", \"Name\", \"SurName\", \"Phone\", \"Email\", \"CreateDate\", \"ParentId\" FROM public.\"Users\" order by \"Id\" asc;").ToList();
            return users ?? new List<User>();
        }

        public void Update(User user)
        {
            user.CreateDate = DateTimeOffset.UtcNow.ToString();
            var query = $"UPDATE public.\"Users\" SET \"Id\"={user.Id}, \"Name\"='{user.Name}', \"SurName\"='{user.SurName}', \"Phone\"='{user.Phone}', \"Email\"='{user.Email}', \"CreateDate\"='{user.CreateDate}', \"ParentId\"={user.ParentId} where \"Id\" = {user.Id};";
            connectionString.Execute(query);
        }
    }
}

