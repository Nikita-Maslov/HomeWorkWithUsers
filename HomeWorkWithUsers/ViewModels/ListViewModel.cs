using System;
using System.Drawing;
using System.Threading.Tasks;
using HomeWorkWithUsers.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeWorkWithUsers.ViewModels
{
	public class UserListViewModel<T>
	{
		public IEnumerable<T> List{ get; set;}
        


        public int totalCount { get; set; }
        public int page { get; set; }
        public int size { get; set; }

        public bool canBack { get; set; }
        public bool canForward { get; set; }


        public UserListViewModel(int totalCount,int page, int size) {
         
            this.page = page;
            this.size = size;

            canBack = page > 0;
            canForward = page * size < totalCount-10;
        }
    }
}

