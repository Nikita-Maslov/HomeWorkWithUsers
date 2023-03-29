using System;
using System.ComponentModel.DataAnnotations;
using LayerApp.BLL.DTO;

namespace HomeWorkWithUsers.ViewModels
{
	public class TaskListViewModel
	{
        public IEnumerable<TaskDTO> ListTask { get; set; }
        public IEnumerable<UserDTO> ListUser { get; set; }

        public int totalCount { get; set; }
        public int page { get; set; }
        public int size { get; set; }

        public bool canBack { get; set; }
        public bool canForward { get; set; }


        public TaskListViewModel(IEnumerable<TaskDTO> ListTask, int page, int size) {
            this.ListTask = ListTask;
            this.page = page;
            this.size = size;

            canBack = page > 0;
            canForward = page * size < ListTask.Count();
        }
    }
}

