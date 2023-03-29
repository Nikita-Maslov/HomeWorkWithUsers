using System;
namespace AppDAL.Entities
{
    public class MyTask {

        // Идентификатор задачи
        public int Id { get; set; }

        // Заголовок
        public String? Subject { get; set; }

        /// Описание задачи
        public String? Description { get; set; }

        // Исполнитель задачи для мапинга формы
        public int ContractorId { get; set; }

        /// Дата создания
        public String? CreateDate { get; set; }

        /// Дата создания
        public String? DeadLineDate{ get; set; }

    }
}

