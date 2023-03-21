using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using HomeWorkWithUsers.Models;

namespace HomeWorkWithUsers.ViewModels
{
	public class AddNewTaskViewModel
	{
        public IEnumerable<UserModel> Contractors { get; set; }

        [Display(Name = "Заголовок")]
        public String Subject { get; set; }

        [Display(Name = "Исполнитель задачи")]
        public int ContractorId { get; set; }

        /// Описание задачи
        [Display(Name = "Описание задачи")]
        public String Description { get; set; }
    }
}

