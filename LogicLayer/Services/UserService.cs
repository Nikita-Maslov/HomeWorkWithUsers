using System;
using AppDAL.Interfaces;
using AutoMapper;
using LayerApp.BLL.DTO;
using LayerApp.BLL.Interfaces;
using AppDAL.Entities;

namespace LayerApp.BLL.Services
{
	public class UserService: IUserService {

        IUnitOfWork db { get; set; }

        public UserService(IUnitOfWork uow) {
            db= uow;
        }

        public void AddUser(UserDTO userDTO) {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, User>()).CreateMapper();
            User user = mapper.Map<UserDTO, User>(userDTO);
            db.User.Create(user);
            db.Save();

        }

        public void DeleteUser(UserDTO userDTO) {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, User>()).CreateMapper();
            User user = mapper.Map<UserDTO, User>(userDTO);
            db.User.Delete(user);
            db.Save();
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public UserDTO GetUser(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<User, UserDTO>(db.User.Get(id));
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, List<UserDTO>>(db.User.GetAll());
            
        }

        public IEnumerable<UserDTO> GetUsersForListView(int skip, int size) {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, List<UserDTO>>(db.User.GetItemsForListView(skip, size));
        }

        public void UpdateUser(UserDTO userDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, User>()).CreateMapper();
            User user = mapper.Map<UserDTO, User>(userDTO);
            db.User.Update(user);
            db.Save();
        }
    }
}

