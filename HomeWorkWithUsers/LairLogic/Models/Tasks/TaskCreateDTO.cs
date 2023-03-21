using System;
using System.ComponentModel.DataAnnotations;

namespace HomeWorkWithUsers.LairLogic.Models.Tasks
{
	public class TaskCreateDTO
	{
        // Заголовок
        [Display(Name = "Заголовок")]
        public string Subject { get; set; }

        // Исполнитель задачи
        [Display(Name = "Исполнитель задачи")]
        public int ContractorId { get; set; }

        // Описание задачи
        [Display(Name = "Описание задачи")]
        public string Description { get; set; }
    }
}

