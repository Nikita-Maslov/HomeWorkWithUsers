using System.ComponentModel.DataAnnotations;
using HomeWorkWithUsers.Data.Domain;

namespace HomeWorkWithUsers.ViewModels {
    public class AddNewTaskViewModel {

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

