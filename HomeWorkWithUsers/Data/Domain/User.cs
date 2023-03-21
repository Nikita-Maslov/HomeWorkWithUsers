using System;
using System.ComponentModel.DataAnnotations;
namespace HomeWorkWithUsers.Data.Domain
{
	
	public class User
	{
        public int Id { get; set; }

        public String Name { get; set; }

        public String SurName { get; set; }

        public String Phone { get; set; }

        public String Email { get; set; }

        public DateTime CreateDate { get; set; }

        public int ParentIdP { get; set; }

	}
}

