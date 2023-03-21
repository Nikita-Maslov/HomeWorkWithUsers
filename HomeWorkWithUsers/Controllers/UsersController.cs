using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using HomeWorkWithUsers.Data.Interface;
using HomeWorkWithUsers.Models;
using HomeWorkWithUsers.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeWorkWithUsers.Controllers {
    public class UsersController : Controller {
       
        private readonly IAllUsers _allUsers;

        public UsersController(IAllUsers allUsers) {
            _allUsers = allUsers;
        }

        // GET: /<controller>/
        public IActionResult Index(int id, [FromQuery(Name = "page")] int page, [FromQuery(Name = "page-size")] int size) {
            
            if (size == 0)
                size = 10;
            
            var skip = page * size;
            ListViewModel<UserModel> obj = new ListViewModel<UserModel>(_allUsers.Users, page, size);

            List<UserModel> a = new List<UserModel>();
            for (int i = skip; i < skip + size; i++) {
                if (i < _allUsers.Users.Count()) {
                    a.Add(_allUsers.Users.ElementAt(i));
                }
            }
            obj.List = a;
            return View(obj);
        }



        public IActionResult AddUser() {
            return View();
        }

        public IActionResult EditUser(UserModel contact) {
            return View(contact);
        }

        [HttpPost]
        public IActionResult Check(UserModel contact) {
            if (ModelState.IsValid) {
                return RedirectToAction("EditUser", contact); 
            }
            return View("Index");
        }

    }

}

