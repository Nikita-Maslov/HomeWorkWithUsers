using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HomeWorkWithUsers.Data.Interface;
using HomeWorkWithUsers.ViewModels;
using HomeWorkWithUsers.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeWorkWithUsers.Controllers
{
    public class TasksController : Controller
    {

        private readonly IAllTasks _allTasks;

        public TasksController(IAllTasks allTasks) {
            _allTasks = allTasks;
        }


        // GET: /<controller>/
        public IActionResult Index(int id, [FromQuery(Name = "page")] int page, [FromQuery(Name = "page-size")] int size) {

            if (size == 0)
                size = 10;

            var skip = page * size;
            ListViewModel<TaskModel> obj = new ListViewModel<TaskModel>(_allTasks.Tasks.Count(), page, size);
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
            return View();
        }

        public IActionResult EditTask(TaskModel contact) {
            return View(contact);
        }

        [HttpPost]
        public IActionResult Check(TaskModel contact) {
            if (ModelState.IsValid) {
                return RedirectToAction("EditTask", contact);
            }
            return View("Index");
        }
    }
}

