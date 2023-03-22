using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using HomeWorkWithUsers.Data.Interface;
using HomeWorkWithUsers.Data.Repository;
using HomeWorkWithUsers.Models;
using HomeWorkWithUsers.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HomeWorkWithUsers.Data.Domain;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeWorkWithUsers.Controllers {
    public class UsersController : Controller {
       
        //private readonly IAllUsers _allUsers;
        private readonly IUserRepository repo;

        /*
        public UsersController(IAllUsers allUsers) {
            _allUsers = allUsers;
        }*/


        public UsersController(IUserRepository r) {
            repo = r;
        }

      
        // GET: /<controller>/
        public IActionResult Index([FromQuery(Name = "page")] int page, [FromQuery(Name = "page-size")] int size) {
            
            if (size == 0)
                size = 10;


            var userList = repo.GetUsers();
            var skip = page * size;
            ListViewModel<User> obj = new ListViewModel<User>(userList, page, size);

            List<User> a = new List<User>();
            for (int i = skip; i < skip + size; i++) {
                if (i < userList.Count()) {
                    a.Add(userList.ElementAt(i));
                }
            }
            obj.List = a;
            return View(obj);
        }


        public IActionResult AddUser() {
            return View();
        }

        public IActionResult EditUser(User contact) {
            return View(contact);
        }

        public IActionResult DeleteUser(User contact, int page) {
            var s = repo.Delete(contact.Id);
            return Redirect("~/Users/Index");
        }

        [HttpPost]
        public IActionResult Check(User contact) {
            repo.Create(contact);
            return Redirect("~/Users/Index");
        }

    }

}

