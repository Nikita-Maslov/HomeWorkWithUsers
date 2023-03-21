using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HomeWorkWithUsers.Data.Domain
{
    public class Task
	{

        // Идентификатор задачи
        public int Id { get; set; }

        // Заголовок
        public String Subject { get; set; }

        // Исполнитель задачи для визуализации
        public User Contractor { get; set; }

        // Исполнитель задачи для мапинга формы
        public int ContractorId { get; set; }


        //Возможные исполнители задачи
        public List<User> Contractors { get; set; }


        /// Описание задачи
        public String Description { get; set; }

	}
}

