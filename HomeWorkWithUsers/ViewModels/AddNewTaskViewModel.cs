using System.ComponentModel.DataAnnotations;
using LayerApp.BLL.DTO;

namespace HomeWorkWithUsers.ViewModels {
    public class AddNewTaskViewModel {

        // Заголовок
        public String? Subject { get; set; }

        // Исполнитель задачи для визуализации
        public TaskDTO? Contractor { get; set; }

        // Исполнитель задачи для мапинга формы
        public int ContractorId { get; set; }

        //Возможные исполнители задачи
        public IEnumerable<UserDTO>? Contractors { get; set; }

        /// Описание задачи
        public String? Description { get; set; }

        /// Дата создания
        public DateTime? CreateDate { get; set; }

        /// Дата дедлайна
        public String? DeadLineDate { get; set; }
    }
}

