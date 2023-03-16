using System;
using HomeWorkWithUsers.Data.Interface;
using HomeWorkWithUsers.Models;

namespace HomeWorkWithUsers.Data.Mocks {
    
    public class MockUsers : IAllUsers {
        public IEnumerable<UserModel> users {
            get {
                List<UserModel> listUser = new List<UserModel>();
                for (int i = 0; i < 100; i++) {
                    listUser.Add(new UserModel(i + 1, $"SurNameUser {i + 1}", $"NameUser {i + 1}", $"{i + 1}.email.ru"));
                }
                return listUser;
            }
        }


        public UserModel getObjectUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}

