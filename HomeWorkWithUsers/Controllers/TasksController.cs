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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeWorkWithUsers.Controllers
{
    public class TasksController : Controller
    {

        private readonly IAllTasks _allTasks;
        private readonly IAllUsers _allUsers;


        public TasksController(IAllTasks allTasks, IAllUsers allUsers) {
            _allTasks = allTasks;
            _allUsers = allUsers;
        }


        // GET: /<controller>/
        public IActionResult Index(int id, [FromQuery(Name = "page")] int page, [FromQuery(Name = "page-size")] int size) {

            if (size == 0)
                size = 10;

            var skip = page * size;

            ListViewModel<TaskModel> obj = new ListViewModel<TaskModel>(_allTasks.Tasks, page, size);

            List<TaskModel> a = new List<TaskModel>();

            for (int i = skip; i < skip + size; i++) {
                if (i < _allTasks.Tasks.Count()) {
                    a.Add(_allTasks.Tasks.ElementAt(i));
                }
            }

            obj.List = a;
            return View(obj);
        }

      
        public IActionResult AddTask() {
            AddNewTaskViewModel obj = new AddNewTaskViewModel();
            obj.Contractors = _allUsers.Users;
            return View(obj);
        }

        public IActionResult EditTask(TaskCreateDTO contact) {
            return View(contact);
        }

        [HttpPost]
        public IActionResult Check(TaskCreateDTO contact) {
            if (ModelState.IsValid) {
                MockTasks mockTasks = new MockTasks();
                mockTasks.Tasks.Append(new TaskModel(_allTasks.Tasks.Last().Id+1, contact.Subject,contact.ContractorId, contact.Description));
               
                return RedirectToAction("EditTask", contact);
            }
            return View("Index");
        }
    }
}

