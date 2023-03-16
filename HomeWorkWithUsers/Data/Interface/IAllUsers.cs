using System;
using HomeWorkWithUsers.Models;
namespace HomeWorkWithUsers.Data.Interface
{
	public interface IAllUsers
	{
		IEnumerable<UserModel> users { get;}
		UserModel getObjectUser(int userId);
	}
}

