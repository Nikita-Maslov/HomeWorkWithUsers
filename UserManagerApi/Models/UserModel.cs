using System;
using System.Xml.Linq;

namespace UserManagerApi.Models
{
	public class UserModel {
        
        public int id { get; set; }

        
        public String name { get; set; }

        
        public String surName { get; set; }

        
        public String email { get; set; }

        public UserModel(int id, String surName, String name, String email) {
            this.id = id;
            this.name = name;
            this.surName = surName;
            this.email = email;
        }
    }
}

