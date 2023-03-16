using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using UserManagerApi.Models;
using UserManagerApi.Data.Interface;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing;
using UserManagerApi.ViewModels;

namespace UserManagerApi.Controllers;

[ApiController]
[Route("[controller]")]

public class ToDoUserController : ControllerBase {

    private readonly IAllUsers _allUsers;

    public ToDoUserController(IAllUsers allUsers) {
        _allUsers = allUsers;
    }

    [HttpGet(Name = "UserList")]
    public ActionResult<UserListViewModel> Get() {
        UserListViewModel obj = new UserListViewModel();
        obj.allUsers = _allUsers.users;
        return obj;
    }

    [HttpGet("{id}")]
    public ActionResult<UserListViewModel> Get(int id) {
        UserListViewModel obj = new UserListViewModel();
        obj.userWithId = _allUsers.getObjectUser(id);
        return obj;
    }
}

