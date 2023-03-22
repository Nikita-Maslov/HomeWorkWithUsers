using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HomeWorkWithUsers.Data.Interface;
using HomeWorkWithUsers.ViewModels;
using HomeWorkWithUsers.Models;
using HomeWorkWithUsers.LairLogic.Models.Tasks;
using HomeWorkWithUsers.Data.Mocks;
using HomeWorkWithUsers.Data.Domain;
using HomeWorkWithUsers.Data.Repository;
using System.Collections;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeWorkWithUsers.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITaskRepository repTask;
        private readonly IUserRepository repUser;

        /*
        public TasksController(IAllTasks allTasks, IAllUsers allUsers) {
            _allTasks = allTasks;
            _allUsers = allUsers;
        }*/

        public TasksController(ITaskRepository rT, IUserRepository rU) {
            repTask = rT;
            repUser = rU;
        }


        // GET: /<controller>/
        public IActionResult Index(int id, [FromQuery(Name = "page")] int page, [FromQuery(Name = "page-size")] int size) {

            if (size == 0)
                size = 10;

            var taskList = repTask.GetTasks();
            var skip = page * size;

            ListViewModel<MyTask> obj = new ListViewModel<MyTask>(taskList, page, size);

            List<MyTask> a = new List<MyTask>();

            for (int i = skip; i < skip + size; i++) {
                if (i < taskList.Count()) {
                    a.Add(taskList.ElementAt(i));
                }
            }

            obj.List = a;
            return View(obj);
        }

      
        public IActionResult AddTask() {
            List<User> taskList = repUser.GetUsers();
            AddNewTaskViewModel obj = new AddNewTaskViewModel();
            obj.Contractors = taskList;
            return View(obj);
        }

        public IActionResult EditTask(MyTask contact) {
            return View(contact);
        }

        [HttpPost]
        public IActionResult CheckCreateTask(MyTask contact) {
            repTask.Create(contact);
            return Redirect("~/Tasks/Index");
        }

        public IActionResult DeleteTask(MyTask contact) {
            var s = repTask.Delete(contact.Id);
            return Redirect("~/Tasks/Index");
        }

        [HttpPost]
        public IActionResult CheckUpdateTask(MyTask contact) {
            repTask.Update(contact);
            return Redirect("~/Tasks/Index");
        }
    }
}

