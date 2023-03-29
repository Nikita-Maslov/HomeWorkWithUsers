using System;
using LayerApp.BLL.DTO;

namespace LayerApp.BLL.Interfaces
{
	public interface IUserService
	{
       UserDTO GetUser(int id);
       void AddUser(UserDTO userDTO);
       void DeleteUser(UserDTO userDTO);
       void UpdateUser(UserDTO userDTO);
        IEnumerable<UserDTO> GetUsers();
        IEnumerable<UserDTO> GetUsersForListView(int skip, int size);
        void Dispose();
    }
}

