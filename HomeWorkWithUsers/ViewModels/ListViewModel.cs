using System;
using System.Drawing;
using System.Threading.Tasks;
using HomeWorkWithUsers.Models;
using HomeWorkWithUsers.Data.Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeWorkWithUsers.ViewModels
{
	public class ListViewModel<T>
	{
		public IEnumerable<T> List{ get; set;}
        public IEnumerable<UserModel> Contractors { get; set; }

        public int totalCount { get; set; }
        public int page { get; set; }
        public int size { get; set; }

        public bool canBack { get; set; }
        public bool canForward { get; set; }


        public ListViewModel(IEnumerable<T> listModel,int page, int size) {
            this.List = listModel;
            this.page = page;
            this.size = size;

            canBack = page > 0;
            canForward = page * size < List.Count()-10;
        }
    }
}

