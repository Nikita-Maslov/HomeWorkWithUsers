using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using AppDAL.EF;
using AutoMapper;
using HomeWorkWithUsers.ViewModels;
using LayerApp.BLL.DTO;
using LayerApp.BLL.Interfaces;
using LayerApp.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace HomeWorkWithUsers.Controllers {

    public class UsersController : Controller {
        /*
        AppDBContext db { get; set; }

        public UsersController(AppDBContext uow) {
            db = uow;
        }*/

        IUserService userService;
        public UsersController(UserService serv) {
            userService = serv;
        }


        // GET: /<controller>/
        public IActionResult Index([FromQuery(Name = "page")] int page, [FromQuery(Name = "page-size")] int size) {

            if (size == 0)
                size = 10;

            var skip = page * size;
            var userList = userService.GetUsersForListView(skip, size);

            UserListViewModel obj = new UserListViewModel(userList, page, size);

            return View(obj);

        }

     
        public IActionResult AddUser() {
            return View();
        }
        
        public IActionResult EditUser(UserDTO contact) {
            return View(contact);
        }

        public IActionResult DeleteUser(UserDTO contact) {
            userService.DeleteUser(contact);
            return Redirect("~/Users/Index");
        }
        
        [HttpPost]
        public IActionResult CheckCreate(UserDTO contact) {
            userService.AddUser(contact);
            return Redirect("~/Users/Index");
        }

        
        [HttpPost]
        public IActionResult CheckUpdate(UserDTO contact) {
            userService.UpdateUser(contact);
            return Redirect("~/Users/Index");
        }
    }

}

