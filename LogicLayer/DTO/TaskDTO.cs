using System;
using LayerApp.BLL.DTO;
using System.ComponentModel.DataAnnotations;
namespace LayerApp.BLL.DTO
{
	public class TaskDTO
	{
        // Идентификатор задачи
        public int? Id { get; set; }

        // Заголовок
        public String? Subject { get; set; }

        /// Описание задачи
        public String? Description { get; set; }

        // Исполнитель задачи для мапинга формы
        public int? ContractorId { get; set; }

        /// Дата создания
        public String? CreateDate { get; set; }

        /// Дата детлайна
        public String? DeadLineDate {get; set; }


        //Возможные исполнители задачи
        public IEnumerable<UserDTO>? Contractors { get; set; }

    }
}

