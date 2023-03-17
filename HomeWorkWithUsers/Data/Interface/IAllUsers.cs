using System;
using HomeWorkWithUsers.Models;
namespace HomeWorkWithUsers.Data.Interface
{
	public interface IAllUsers
	{
		IEnumerable<UserModel> Users {get;}
		UserModel GetObjectUser(int userId);
	}
}

