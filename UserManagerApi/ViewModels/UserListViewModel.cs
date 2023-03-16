using System;
using System.Drawing;
using System.Threading.Tasks;
using UserManagerApi.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UserManagerApi.ViewModels
{
	public class UserListViewModel
	{
		public IEnumerable<UserModel> allUsers { get; set;}
		public UserModel userWithId { get; set;}
    }
}

