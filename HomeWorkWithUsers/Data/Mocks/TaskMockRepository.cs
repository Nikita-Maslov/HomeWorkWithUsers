using System;
using Dapper;
using Npgsql;
using HomeWorkWithUsers.Data.Repository;
using HomeWorkWithUsers.Data.Domain;
using Microsoft.SqlServer.Management.Smo;

namespace HomeWorkWithUsers.Data.Mocks
{
	public class TaskMockRepository : ITaskRepository
	{
        private readonly NpgsqlConnection connectionString;

        public TaskMockRepository(string connectionString) {
            this.connectionString = new NpgsqlConnection(connectionString);
        }

        public void Create(MyTask item)
        {
            item.Id = connectionString.ExecuteScalar<int>("SELECT max(\"Id\") FROM public.\"Tasks\"");
            item.CreateDate = DateTimeOffset.UtcNow.ToString();
            var query = $"INSERT INTO public.\"Tasks\" (\"Id\",\"Subject\", \"Description\", \"Contractorid\", \"Createdate\") " +
            $"VALUES({(item.Id) + 1},'{item.Subject}', '{item.Description}', {item.ContractorId}, '{item.CreateDate}');";
            connectionString.Execute(query);
        }
        public string Delete(int id)
        {
            String s;
            var query = "DELETE FROM public.\"Tasks\" WHERE \"Id\"" + $" = {id};";
            try {
                var result = connectionString.Execute(query);
                s = "запрос выполнен";
            }
            catch {
                s = "";
            }
            return s;
        }
        public MyTask Get(int id)
        {
            throw new NotImplementedException();
        }
        public List<MyTask> GetTasks() {
            var task = connectionString.Query<MyTask>("SELECT \"Id\", \"Subject\", \"Description\", \"Contractorid\", \"Initiatorid\", \"Createdate\", \"Deadlinedate\" FROM public.\"Tasks\" order by \"Id\" asc;").ToList();
            return task ?? new List<MyTask>();
        }
        public void Update(MyTask item)
        {
            item.CreateDate = DateTimeOffset.UtcNow.ToString();
            var query = $"UPDATE public.\"Tasks\" SET \"Id\"={item.Id}, \"Subject\"='{item.Subject}', \"Description\"='{item.Description}', \"Contractorid\"={item.ContractorId}, \"Createdate\"='{item.CreateDate}' where \"Id\" = {item.Id};";
            connectionString.Execute(query);
        }
    }
}

