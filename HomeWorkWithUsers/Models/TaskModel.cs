using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HomeWorkWithUsers.Models
{
    public class TaskModel
	{

        // Идентификатор задачи
        [Display(Name = "id")]
        public int Id { get; set; }


        // Заголовок
        [Display(Name = "Заголовок")]
        public String Subject { get; set; }


        // Исполнитель задачи для визуализации
        [Display(Name = "Исполнитель задачи")]
        public UserModel Contractor { get; set; }



        // Исполнитель задачи для мапинга формы
        [Display(Name = "Исполнитель задачи")]
        public int ContractorId { get; set; }


        //Возможные исполнители задачи
        [Display(Name = "Исполнители задачи")]
        public List<UserModel> Contractors { get; set; }


        /// Описание задачи
        [Display(Name = "Описание задачи")]
        public String Description { get; set; }

        public TaskModel(int Id, String Subject, int ContractorId, String Description) {
            this.Id = Id;
            this.Subject = Subject;
            this.ContractorId = ContractorId;
            this.Description = Description;
        }
	}
}

