using System;
using System.ComponentModel.DataAnnotations;
namespace HomeWorkWithUsers.Models
{
	
	public class UserModel
	{
        [Display(Name = "id")]
        public int id { get; set; }

        [Display(Name ="Имя")]
        public String name { get; set; }

        [Display(Name = "Фамилия")]
        public String surName { get; set; }

        [Display(Name = "Емайл")]
        public String email { get; set; }

        public UserModel() { }

        public UserModel(int id, String surName, String name, String email){
            this.id = id;
            this.name = name;
            this.surName = surName;
            this.email = email;
        }
	}
}

