using System;
using System.Collections.Generic;
using HomeWorkWithUsers.Models;

namespace HomeWorkWithUsers.Data.Interface
{
	public interface IAllTasks
	{
        IEnumerable<TaskModel> Tasks{ get; }
        TaskModel GetObjectTask(int userId);
    }
}

