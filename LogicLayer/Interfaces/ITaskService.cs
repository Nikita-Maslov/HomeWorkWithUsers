using System;
using LayerApp.BLL.DTO;

namespace LayerApp.BLL.Interfaces
{
	public interface ITaskService
	{
        UserDTO GetTask(int? id);
        void AddTask(TaskDTO taskDTO);
        void DeleteTask(TaskDTO taskDTO);
        void UpdateTask(TaskDTO taskDTO);
        IEnumerable<TaskDTO> GetTasks();
        IEnumerable<TaskDTO> GetTasksForListView(int skip, int size);
        void Dispose();
    }
}

