using System;
using System.Collections.Generic;
using System.Drawing;
using AppDAL.Entities;
using AppDAL.Interfaces;
using AutoMapper;
using Azure;
using LayerApp.BLL.DTO;
using LayerApp.BLL.Interfaces;

namespace LayerApp.BLL.Services
{
	public class TaskService : ITaskService
	{
        IUnitOfWork db { get; set; }

        public TaskService(IUnitOfWork uow) {
            db = uow;
        }

        public void AddTask(TaskDTO taskDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskDTO, MyTask>()).CreateMapper();
            MyTask task = mapper.Map<TaskDTO, MyTask>(taskDTO);
            db.MyTask.Create(task);
            db.Save();
        }

        public void DeleteTask(TaskDTO taskDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskDTO, MyTask>()).CreateMapper();
            MyTask task = mapper.Map<TaskDTO, MyTask>(taskDTO);
            db.MyTask.Delete(task);
            db.Save();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public UserDTO GetTask(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TaskDTO> GetTasks()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<MyTask, TaskDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<MyTask>, List<TaskDTO>>(db.MyTask.GetAll());
        }
        public IEnumerable<TaskDTO> GetTasksForListView(int skip, int size) {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<MyTask, TaskDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<MyTask>, List<TaskDTO>>(db.MyTask.GetItemsForListView(skip, size));
        }

            public void UpdateTask(TaskDTO taskDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskDTO, MyTask>()).CreateMapper();
            MyTask task = mapper.Map<TaskDTO, MyTask>(taskDTO);
            db.MyTask.Update(task);
            db.Save();
        }
    }
}

