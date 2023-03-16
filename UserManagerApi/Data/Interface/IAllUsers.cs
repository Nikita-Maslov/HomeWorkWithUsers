using System;
using UserManagerApi.Models;
namespace UserManagerApi.Data.Interface
{
	public interface IAllUsers
	{
		IEnumerable<UserModel> users { get;}
		UserModel getObjectUser(int userId);
	}
}

