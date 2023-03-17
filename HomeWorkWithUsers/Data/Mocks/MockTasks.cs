using System;
using System.Collections.Generic;
using HomeWorkWithUsers.Data.Interface;
using HomeWorkWithUsers.Data.Mocks;
using HomeWorkWithUsers.Models;


namespace HomeWorkWithUsers.Data.Mocks
{
	public class MockTasks : IAllTasks {

        public IEnumerable<TaskModel> Tasks {
            get {
                Random rnd = new Random();
                List<TaskModel> listTasks = new List<TaskModel>();
                for (int i = 1; i <=55; i++) {
                    int contractorId = rnd.Next(1, 100); 
                    listTasks.Add(new TaskModel(i, $"Task{i}", contractorId, $"Description of task {i}. Created {DateTime.Now.ToString()}"));
                }
                return listTasks;
            }
        }

        public TaskModel GetObjectTask(int userId)
        {
            throw new NotImplementedException();
        }
    }
}

