using System;
using System.ComponentModel.DataAnnotations;
namespace HomeWorkWithUsers.Data.Domain
{
	
	public class User
	{
        [Display(Name = "id")]
        public int Id { get; set; }

        [Display(Name = "Имя")]
        public String Name { get; set; }

        [Display(Name = "Фамилия")]
        public String SurName { get; set; }

        [Display(Name = "Телефон")]
        public String Phone { get; set; }

        [Display(Name = "Емайл")]
        public String Email { get; set; }

        [Display(Name = "Дата")]
        public String CreateDate { get; set; }

        [Display(Name = "Родители")]
        public int ParentId { get; set; }

	}
}

