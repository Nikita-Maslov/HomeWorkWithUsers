using System;
using System.Drawing;
using System.Threading.Tasks;
using HomeWorkWithUsers.Models;
using LayerApp.BLL.DTO;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeWorkWithUsers.ViewModels
{
	public class UserListViewModel {
		public IEnumerable<UserDTO> ListUser{ get; set;}

        public int totalCount { get; set; }
        public int page { get; set; }
        public int size { get; set; }

        public bool canBack { get; set; }
        public bool canForward { get; set; }


        public UserListViewModel(IEnumerable<UserDTO> ListUser, int page, int size) {
            this.ListUser = ListUser;
            this.page = page;
            this.size = size;

            canBack = page > 0;
            canForward = page * size < ListUser.Count();
        }
    }
}

