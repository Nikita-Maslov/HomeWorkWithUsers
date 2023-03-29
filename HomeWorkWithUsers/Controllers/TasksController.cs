using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HomeWorkWithUsers.ViewModels;
using HomeWorkWithUsers.Models;
using System.Collections;
using LayerApp.BLL.Interfaces;
using LayerApp.BLL.Services;
using LayerApp.BLL.DTO;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeWorkWithUsers.Controllers
{
    public class TasksController : Controller
    {

        ITaskService taskService;
        IUserService userService;
        public TasksController(TaskService taskService, UserService userService) {
            this.taskService = taskService; ;
            this.userService = userService;
        }


        // GET: /<controller>/
        public IActionResult Index(int id, [FromQuery(Name = "page")] int page, [FromQuery(Name = "page-size")] int size) {

            if (size == 0)
                size = 10;
            var skip = page * size;

            var taskList = taskService.GetTasksForListView(skip,size);
            var taskUser = userService.GetUsers();
            
            
            TaskListViewModel obj = new TaskListViewModel(taskList, page, size);
           
            if (taskUser != null) {
                obj.ListUser = taskUser;
            }
            return View(obj);
        }

      
        public IActionResult AddTask() {
            IEnumerable<UserDTO> taskList = userService.GetUsers();
            AddNewTaskViewModel obj = new AddNewTaskViewModel();
            obj.Contractors = taskList;
            obj.CreateDate = DateTime.Now;
            return View(obj);
        }

        [HttpPost]
        public IActionResult CheckCreateTask(TaskDTO contact) {
            taskService.AddTask(contact);
            return Redirect("~/Tasks/Index");
        }

        public IActionResult DeleteTask(TaskDTO contact) {
            taskService.DeleteTask(contact);
            return Redirect("~/Tasks/Index");
        }

        
        public IActionResult EditTask(TaskDTO contact) {
            contact.Contractors = userService.GetUsers();
            return View(contact);
        }

        
        [HttpPost]
        public IActionResult CheckUpdateTask(TaskDTO contact) {
            taskService.UpdateTask(contact);
            return Redirect("~/Tasks/Index");
        }
    }
}

